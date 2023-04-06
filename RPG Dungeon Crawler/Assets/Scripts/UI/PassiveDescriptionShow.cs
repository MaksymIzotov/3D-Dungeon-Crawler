using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassiveDescriptionShow : MonoBehaviour
{
    #region SingletonInit

    public static PassiveDescriptionShow Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private bool isOn = false;

    [SerializeField] private Transform description;
    [SerializeField] private Transform positionOn;
    [SerializeField] private Transform positionOff;

    [SerializeField] private float speed;
    [SerializeField] private GameObject iconPrefab;

    private List<GameObject> iconItem = new List<GameObject>();

    public void Toggle(bool state)
    {
        CreatePassiveIcons();

        isOn = state;

        if (isOn) {
            description.gameObject.SetActive(true);
        }
        else
        {
            foreach (GameObject item in iconItem)
            {
                item.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    private void CreatePassiveIcons()
    {
        foreach (Transform child in description) {
            Destroy(child.gameObject);
        }
        iconItem.Clear();

        List<PassiveDescription> descriptions = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG).GetComponent<PlayerPassives>().activePassives;

        foreach(PassiveDescription desc in descriptions)
        {
            GameObject icon = Instantiate(iconPrefab, description);

            icon.GetComponent<Image>().sprite = desc.icon;
            icon.GetComponentInChildren<TMP_Text>().text = desc.description;
            icon.GetComponentInChildren<TMP_Text>().gameObject.SetActive(false);

            iconItem.Add(icon);
        }
    }

    public void UpdatePassives()
    {
        CreatePassiveIcons();
    }

    private void Update()
    {
        MovePassiveDescription();
    }

    private void MovePassiveDescription()
    {
        if (description.gameObject.activeSelf == false) { return; }

        if (isOn)
        {
            if (Vector3.Distance(description.GetComponent<RectTransform>().anchoredPosition, positionOn.GetComponent<RectTransform>().anchoredPosition) < 0.001f)
            {
                foreach (GameObject item in iconItem)
                {
                    item.transform.GetChild(0).gameObject.SetActive(true);
                }
                return;
            }

            var step = speed * Time.deltaTime;
            description.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(description.GetComponent<RectTransform>().anchoredPosition, positionOn.GetComponent<RectTransform>().anchoredPosition, step);
        }
        else
        {
            var step = speed * Time.deltaTime;
            description.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(description.GetComponent<RectTransform>().anchoredPosition, positionOff.GetComponent<RectTransform>().anchoredPosition, step);

            if (Vector3.Distance(description.GetComponent<RectTransform>().anchoredPosition, positionOff.GetComponent<RectTransform>().anchoredPosition) < 0.001f) description.gameObject.SetActive(false);
        }
    }
}
