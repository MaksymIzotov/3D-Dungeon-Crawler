using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableHealingPotionController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float force;
    [SerializeField] private float torqueForce;
    

    [SerializeField] private GameObject healingAreaPrefab;

    private float regenAmount;

    private bool isColliding = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Throw();
    }

    public void SetupHealing(float _regenAmount)
    {
        regenAmount = _regenAmount;
    }

    private void Throw()
    {
        Vector3 torque;

        rb.AddForce(transform.forward * force, ForceMode.Impulse);

        torque.x = Random.Range(-torqueForce, torqueForce);
        torque.y = Random.Range(-torqueForce, torqueForce);
        torque.z = Random.Range(-torqueForce, torqueForce);

        rb.AddTorque(torque, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) { return; }
        isColliding = true;      

        DestroyObject();
    }

    private void DestroyObject()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, 0, transform.position.z);

        GameObject healingArea = Instantiate(healingAreaPrefab, spawnPos, Quaternion.Euler(-90,0,0));
        healingArea.GetComponent<HealingAreaController>().Setup(regenAmount);

        Destroy(gameObject);
    }
}
