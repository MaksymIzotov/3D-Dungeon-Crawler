using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TutorialStepsShow : MonoBehaviour
{
    [Serializable]
    public struct TutorialStep
    {
        [TextArea]
        public string text;
        public bool doLock;
        public UnityEvent action;
        public UnityEvent finishedAction;
    }

    [SerializeField] private TutorialStep[] tutorialSteps;

    [SerializeField] private GameObject tutorialBackground;
    [SerializeField] private GameObject nextStep;
    [SerializeField] private TMP_Text tutorialText;

    private bool isLocked;
    private bool isCoroutineRunning = false;

    private int index = -1;

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
        isLocked = false;
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
