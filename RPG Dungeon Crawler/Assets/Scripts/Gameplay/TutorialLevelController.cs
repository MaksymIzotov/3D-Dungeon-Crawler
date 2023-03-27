using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class TutorialLevelController : MonoBehaviour
{
    [System.Serializable]
    public struct TutorialStep {
        [TextAreaAttribute]
        public string text;
        public bool doLock;
        public UnityEvent action;
        public UnityEvent finishedAction;
    }

    [SerializeField] private TutorialStep[] tutorialSteps;

    [SerializeField] private GameObject tutorialBackground;
    [SerializeField] private GameObject nextStep;
    [SerializeField] private TMP_Text tutorialText;

    [SerializeField] private Spell[] tutorialSpells;
    [SerializeField] private Item tutorialArmor;

    private bool isLocked;
    private bool isCoroutineRunning = false;

    private int index = -1;

    private void Awake()
    {
        GetTutorialSpells();
    }

    void Start()
    {
        GetComponent<PlayerSpawner>().SpawnPlayer();
        NavMeshBaking.Instance.BuildNavMesh();

        Invoke("UpdateTutorialStep", 1);
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

    private void Update()
    {
        if (isLocked) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isCoroutineRunning)
            {
                StopAllCoroutines();
                isCoroutineRunning = false;
                tutorialText.text = tutorialSteps[index].text;
                nextStep.SetActive(true);
            }
            else
            {
                UpdateTutorialStep();
            }
        }          
    }

    public void ExitTutorial()
    {
        ClearSpells();
        LevelManager.Instance.onLevelCompleted.Invoke();
    }

    public void SetLock(bool _isLocked)
    {
        isLocked = _isLocked;

        if (!isLocked)
        {
            index++;

            if (index >= tutorialSteps.Length) return;

            tutorialSteps[index].action.Invoke();
            StartCoroutine(BuildText());
        }
    }

    public void UpdateTutorialStep()
    {
        StopAllCoroutines();
        tutorialBackground.SetActive(false);

        if (index >= 0)
        {
            tutorialSteps[index].finishedAction.Invoke();

            if (tutorialSteps[index].doLock)
            {
                SetLock(true);
                return;
            }
        }
    
        index++;

        if (index >= tutorialSteps.Length) return;

        tutorialSteps[index].action.Invoke();
        StartCoroutine(BuildText());
    }

    private IEnumerator BuildText()
    { 
        tutorialBackground.SetActive(true);
        nextStep.SetActive(false);
        tutorialText.text = "";
        isCoroutineRunning = true;

        for (int i = 0; i < tutorialSteps[index].text.Length; i++)
        {
            tutorialText.text = string.Concat(tutorialText.text, tutorialSteps[index].text[i]);
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSeconds(0.07f);
        }

        isCoroutineRunning = false;
        nextStep.SetActive(true);
    }
}
