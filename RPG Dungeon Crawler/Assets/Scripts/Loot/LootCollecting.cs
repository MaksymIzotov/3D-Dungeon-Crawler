using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LootCollecting : MonoBehaviour
{
    [SerializeField] private float speed = 12f;

    private bool isNear = false;
    private GameObject player;

    UnityAction onPickup;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);
    }

    private void Update()
    {
        if (!isNear) { return; }

        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) < 0.5f)
            PickupItem();  
    }

    private void PickupItem()
    {
        onPickup.Invoke();
        Destroy(gameObject);
    }

    public void Collect(UnityAction _onPickup)
    {
        onPickup = _onPickup;
        isNear = true;
    }
}
