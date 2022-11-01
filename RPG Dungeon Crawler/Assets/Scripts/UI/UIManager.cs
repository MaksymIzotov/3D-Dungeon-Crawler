using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton Init
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject InteractionText;


    private string interactionInfo = "";
    private bool isInteraction = false;
    public void UpdateHealth(float hp)
    {
        healthText.text = hp.ToString("F0");
    }

    public void UpdateInteraction(bool isActive, string text)
    {
        if(isInteraction != isActive)
        {
            isInteraction = isActive;
            InteractionText.SetActive(isActive);
        }

        if(interactionInfo != text)
        {
            interactionInfo = text;
            InteractionText.GetComponent<TMP_Text>().text = "Press key to " + text; //Change "key" to actual key
        }
    }
}
