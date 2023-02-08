using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuNotification : MonoBehaviour
{
    #region Singleton Init

    public static MenuNotification Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    [SerializeField] private GameObject messagePrefab;
    [SerializeField] private Transform messageParent;

    public void ShowMessage(string message)
    {
        GameObject text = Instantiate(messagePrefab, messageParent);
        text.transform.SetSiblingIndex(messageParent.transform.childCount-2);

        text.GetComponent<TMP_Text>().text = message;
    }
}
