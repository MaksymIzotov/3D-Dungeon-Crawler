using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LootCollecting : MonoBehaviour
{
    public Item info;

    [Space(10)]
    [Header("LEAVE EMPTY IF NOT MONEY")]
    [SerializeField] private ExtensionMethods.MoneyType type;
    [SerializeField] private int amountMin;
    [SerializeField] private int amountMax;

    [Space(10)]

    [SerializeField] private float speed = 15f;
    [SerializeField] private AudioClip pickupSound;

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

        if (Vector3.Distance(transform.position, player.position) < 0.7f)
            PickupItem();  
    }

    private void PickupItem()
    {
        int amount = Random.Range(amountMin, amountMax);

        InGameSoundFX.Instance.PlaySoundFX(pickupSound);

        if (info != null)
            player.GetComponent<ItemPickup>().PickupItem(info);
        else
            player.GetComponent<ItemPickup>().PickupItem(amount, type);

        Destroy(gameObject);
    }

    public void Collect()
    {
        isNear = true;
    }
}
