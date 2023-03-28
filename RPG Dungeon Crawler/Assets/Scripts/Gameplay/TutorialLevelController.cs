using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class TutorialLevelController : MonoBehaviour
{
    [SerializeField] private Spell[] tutorialSpells;
    [SerializeField] private Item tutorialArmor;

    private void Awake()
    {
        GetTutorialSpells();
    }

    void Start()
    {
        GetComponent<PlayerSpawner>().SpawnPlayer();
        NavMeshBaking.Instance.BuildNavMesh();

        GetComponent<TutorialStepsShow>().SetLock(true);
        GetComponent<TutorialStepsShow>().Invoke("UpdateTutorialStep", 2);
    }

    private void GetTutorialSpells()
    {
        for (int i = 0; i < tutorialSpells.Length; i++)
        {
            LootInventory.Instance.inventory.equipedSpells[i] = tutorialSpells[i];
        }

        LootInventory.Instance.inventory.armor = tutorialArmor;
    }

    private void ClearSpells()
    {
        for (int i = 0; i < 4; i++)
        {
            LootInventory.Instance.inventory.equipedSpells[i] = null;
        }

        LootInventory.Instance.inventory.armor = null;
    }

    public void ExitTutorial()
    {
        ClearSpells();
        LevelManager.Instance.onLevelCompleted.Invoke();
    }   
}
