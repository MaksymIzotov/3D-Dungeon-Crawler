using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTotemController : MonoBehaviour, IInteractable
{
    [SerializeField] private string info;

    public string GetInteractedInfo()
    {
        return info;
    }

    public void Interact()
    {
        //Spawn enemies
    }
}
