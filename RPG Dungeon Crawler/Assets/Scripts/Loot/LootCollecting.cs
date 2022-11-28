using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LootCollecting : MonoBehaviour
{
    public LootInfo info;

    [SerializeField] private float speed = 12f;

    private bool isNear = false;
    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG).transform;
    }

    private void Update()
    {
        if (!isNear) { return; }

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.position) < 0.5f)
            PickupItem();  
    }

    private void PickupItem()
    {
        player.GetComponent<ItemPickup>().PickupItem(info);
        Destroy(gameObject);
    }

    public void Collect()
    {
        isNear = true;
    }
}
