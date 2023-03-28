using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DEBUG : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject enemyPrefab;

    private void Start()
    {
        //Invoke("SpawnEnemyAtFirstRoom", 5);
    }

    public void SpawnEnemyAtFirstRoom()
    {
        GameObject player = Instantiate(enemyPrefab, PlayerSpawner.Instance.GetSpawnPoint().transform.position, Quaternion.identity);
    }

    public void Update()
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Mouse Over: " + eventData.pointerCurrentRaycast.gameObject.name);
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            
        }
    }
}