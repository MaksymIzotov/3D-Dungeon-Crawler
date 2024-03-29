using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    [SerializeField] GameObject[] bodyParts;
    [SerializeField] float explosionForce = 1f;
    [SerializeField] float rotationalForce = 1f;

    public void Explode()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].transform.parent = bodyParts[i].transform.root;
            bodyParts[i].GetComponent<Rigidbody>().isKinematic = false;


            if(bodyParts[i].GetComponent<CapsuleCollider>() != null) 
                bodyParts[i].GetComponent<CapsuleCollider>().enabled = true;
            else if(bodyParts[i].GetComponent<SphereCollider>() != null)
                bodyParts[i].GetComponent<SphereCollider>().enabled = true;
            else if(bodyParts[i].GetComponent<MeshCollider>() != null)
                bodyParts[i].GetComponent<MeshCollider>().enabled = true;


            bodyParts[i].GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)) * explosionForce, ForceMode.Impulse);
            bodyParts[i].GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * rotationalForce, ForceMode.Impulse);
        }
    }
}
