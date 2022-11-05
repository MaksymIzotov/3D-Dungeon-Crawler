using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebindResetAll : MonoBehaviour
{
    [SerializeField] private GameObject[] resetButtons;

    public void ResetAll()
    {
        for (int i = 0; i < resetButtons.Length; i++)
        {
            resetButtons[i].GetComponent<Button>().onClick.Invoke();
        }
    }
}
