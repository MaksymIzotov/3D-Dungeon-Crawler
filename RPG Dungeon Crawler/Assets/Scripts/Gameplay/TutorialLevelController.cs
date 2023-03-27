using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TutorialLevelController : MonoBehaviour
{
    [System.Serializable]
    public struct TutorialStep {
        [TextAreaAttribute]
        public string text;
        public UnityEvent action;
        public UnityEvent finishedAction;
    }

    [SerializeField] private TutorialStep[] tutorialSteps;

    [SerializeField] private GameObject tutorialBackground;
    [SerializeField] private GameObject nextStep;
    [SerializeField] private TMP_Text tutorialText;
  
    private int index = -1;

    void Start()
    {
        GetComponent<PlayerSpawner>().SpawnPlayer();
        NavMeshBaking.Instance.BuildNavMesh();

        Invoke("UpdateTutorialStep", 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            UpdateTutorialStep();
    }

    public void UpdateTutorialStep()
    {
        StopAllCoroutines();

        if (index >= 0)
            tutorialSteps[index].finishedAction.Invoke();

        tutorialBackground.SetActive(false);
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

        for (int i = 0; i < tutorialSteps[index].text.Length; i++)
        {
            tutorialText.text = string.Concat(tutorialText.text, tutorialSteps[index].text[i]);
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSeconds(0.07f);
        }

        nextStep.SetActive(true);
    }
}
