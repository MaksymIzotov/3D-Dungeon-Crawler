﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Graphs;
using UnityEngine.AI;

public class Generator2D : MonoBehaviour {
    enum CellType {
        None,
        Room,
        Hallway
    }

    class Room {
        public RectInt bounds;

        public Room(Vector2Int location, Vector2Int size) {
            bounds = new RectInt(location, size);
        }

        public static bool Intersect(Room a, Room b) {
            return !((a.bounds.position.x >= (b.bounds.position.x + b.bounds.size.x)) || ((a.bounds.position.x + a.bounds.size.x) <= b.bounds.position.x)
                || (a.bounds.position.y >= (b.bounds.position.y + b.bounds.size.y)) || ((a.bounds.position.y + a.bounds.size.y) <= b.bounds.position.y));
        }
    }


    [SerializeField]
    Vector2Int size;
    [SerializeField]
    int roomCount;
    [SerializeField]
    int roomMinSize;
    [SerializeField]
    int roomMaxSize;
    [SerializeField]
    GameObject[] corridorPrefab;
    [SerializeField]
    GameObject[] roomsPrefab3x3;
    [SerializeField]
    GameObject[] roomsPrefab4x4;
    [SerializeField]
    GameObject[] roomsPrefab5x5;
    [SerializeField]
    GameObject[] roomsPrefab6x6;

    Random random;
    Grid2D<CellType> grid;
    List<Room> rooms;
    Delaunay2D delaunay;
    HashSet<Prim.Edge> selectedEdges;

    List<Vector2Int> occupiedPos;
    List<GameObject> Instances;
    GameObject dungeon;

    private void Awake()
    {
        Generate();
    }

    private void Start()
    {
        PlayerSpawner.Instance.SpawnPlayer();
        Invoke("BuildNavMesh", 0.1f);
    }

    private void Generate() {
        occupiedPos = new List<Vector2Int>();
        random = new Random();
        grid = new Grid2D<CellType>(size, Vector2Int.zero);
        rooms = new List<Room>();
        Instances = new List<GameObject>();

        DungeonParentSetup();
        PlaceRooms();
        Triangulate();
        CreateHallways();
        PathfindHallways();

        dungeon.transform.localScale = new Vector3(10, 10, 10);

        GameObject[] gos = Instances.ToArray();
        StaticBatchingUtility.Combine(gos, dungeon);
    }

    private void DestroyWalls(GameObject parent)
    {
        Transform[] allChildren = parent.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Checker")
            {
                int layerMask = 1 << 12;

                Collider[] hitColliders = Physics.OverlapSphere(child.position, 0.01f, layerMask);
                Debug.Log(hitColliders.Length);
                if (hitColliders.Length == 2)
                {
                    Destroy(hitColliders[0].transform.parent.gameObject);
                    Destroy(hitColliders[1].transform.parent.gameObject);
                }

            }
        }
    }

    private void BuildNavMesh()
    {
        List<NavMeshSurface> navMeshes = new List<NavMeshSurface>();
        foreach (GameObject n in Instances)
        {
            if (n == null) { continue; }

            if (n.GetComponent<NavMeshSurface>() != null)
                navMeshes.Add(n.GetComponent<NavMeshSurface>());
        }
        NavMeshSurface[] surfaces = navMeshes.ToArray();
        NavMeshBaking.Instance.BuildNavMesh(surfaces);
    }

    void DungeonParentSetup()
    {
        dungeon = new GameObject("Dungeon");
        dungeon.transform.position = Vector3.zero;
        dungeon.isStatic = true;
    }

    void PlaceRooms() {
        for (int i = 0; i < roomCount; i++) {
            Vector2Int location = new Vector2Int(
                random.Next(0, size.x),
                random.Next(0, size.y)
            );

            int _roomSize = random.Next(roomMinSize, roomMaxSize + 1);

            Vector2Int roomSize = new Vector2Int(
                _roomSize,
                _roomSize
            );

            bool add = true;
            Room newRoom = new Room(location, roomSize);
            Room buffer = new Room(location + new Vector2Int(-1, -1), roomSize + new Vector2Int(2, 2));

            foreach (var room in rooms) {
                if (Room.Intersect(room, buffer)) {
                    add = false;
                    break;
                }
            }

            if (newRoom.bounds.xMin < 0 || newRoom.bounds.xMax >= size.x
                || newRoom.bounds.yMin < 0 || newRoom.bounds.yMax >= size.y) {
                add = false;
            }

            if (add) {
                rooms.Add(newRoom);
                PlaceRoom(newRoom.bounds.position, newRoom.bounds.size);

                foreach (var pos in newRoom.bounds.allPositionsWithin) {
                    grid[pos] = CellType.Room;
                }
            }
        }
    }

    void Triangulate() {
        List<Vertex> vertices = new List<Vertex>();

        foreach (var room in rooms) {
            vertices.Add(new Vertex<Room>((Vector2)room.bounds.position + ((Vector2)room.bounds.size) / 2, room));
        }

        delaunay = Delaunay2D.Triangulate(vertices);
    }

    void CreateHallways() {
        List<Prim.Edge> edges = new List<Prim.Edge>();

        foreach (var edge in delaunay.Edges) {
            edges.Add(new Prim.Edge(edge.U, edge.V));
        }

        List<Prim.Edge> mst = Prim.MinimumSpanningTree(edges, edges[0].U);

        selectedEdges = new HashSet<Prim.Edge>(mst);
        var remainingEdges = new HashSet<Prim.Edge>(edges);
        remainingEdges.ExceptWith(selectedEdges);

        foreach (var edge in remainingEdges) {
            if (random.NextDouble() < 0.125) {
                selectedEdges.Add(edge);
            }
        }
    }

    void PathfindHallways() {
        DungeonPathfinder2D aStar = new DungeonPathfinder2D(size);

        foreach (var edge in selectedEdges) {
            var startRoom = (edge.U as Vertex<Room>).Item;
            var endRoom = (edge.V as Vertex<Room>).Item;

            var startPosf = startRoom.bounds.center;
            var endPosf = endRoom.bounds.center;
            var startPos = new Vector2Int((int)startPosf.x, (int)startPosf.y);
            var endPos = new Vector2Int((int)endPosf.x, (int)endPosf.y);

            var path = aStar.FindPath(startPos, endPos, (DungeonPathfinder2D.Node a, DungeonPathfinder2D.Node b) => {
                var pathCost = new DungeonPathfinder2D.PathCost();
                
                pathCost.cost = Vector2Int.Distance(b.Position, endPos);    //heuristic

                if (grid[b.Position] == CellType.Room) {
                    pathCost.cost += 10;
                } else if (grid[b.Position] == CellType.None) {
                    pathCost.cost += 5;
                } else if (grid[b.Position] == CellType.Hallway) {
                    pathCost.cost += 1;
                }

                pathCost.traversable = true;

                return pathCost;
            });

            if (path != null) {
                for (int i = 0; i < path.Count; i++) {
                    var current = path[i];

                    if (grid[current] == CellType.None) {
                        grid[current] = CellType.Hallway;
                    }

                    if (i > 0) {
                        var prev = path[i - 1];

                        var delta = current - prev;
                    }
                }

                foreach (var pos in path) {
                    if (grid[pos] == CellType.Hallway)
                    {
                        bool isOccupied = false;

                        foreach (Vector2Int occupied in occupiedPos)
                        {
                            if (occupied == pos)
                            {
                                isOccupied = true;
                                break;
                            }
                        }

                        if (!isOccupied)
                            PlaceHallway(pos);
                    }
                }
            }
        }
    }

    void PlaceRoom(Vector2Int location, Vector2Int size) {
       

        switch (size.x)
        {
            case 3:
                PlaceRoomInstance(roomsPrefab3x3, location, size);
                break;
            case 4:
                PlaceRoomInstance(roomsPrefab4x4, location, size);
                break;
            case 5:
                PlaceRoomInstance(roomsPrefab5x5, location, size);
                break;
            case 6:
                PlaceRoomInstance(roomsPrefab6x6, location, size);
                break;
        }
    }

    private void PlaceRoomInstance(GameObject[] roomArray, Vector2Int location, Vector2Int size)
    {
        GameObject spawnedRoom = Instantiate(roomArray[random.Next(0, roomArray.Length)], new Vector3(location.x, 0, location.y), Quaternion.identity);
        spawnedRoom.transform.parent = dungeon.transform;

        DestroyWalls(spawnedRoom);

        CombineMeshes(ref spawnedRoom);

        Instances.Add(spawnedRoom);
    }

    void PlaceHallway(Vector2Int location) {
        GameObject corridor = Instantiate(corridorPrefab[random.Next(0, corridorPrefab.Length)], new Vector3(location.x, 0, location.y), Quaternion.identity);
        corridor.transform.parent = dungeon.transform;

        DestroyWalls(corridor);

        CombineMeshes(ref corridor);

        Instances.Add(corridor);

        occupiedPos.Add(location);
    }

    private void CombineMeshes(ref GameObject root)
    {
        List<GameObject> go = new List<GameObject>();
        Transform[] children = root.transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.gameObject.GetComponent<MeshFilter>() != null)
            {
                Instances.Add(child.gameObject);
            }
        }
    }
}
