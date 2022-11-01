using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

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

    [SerializeField] private RebindJumping input;

    private string interactionInfo = "";
    private bool isInteraction = false;

    private void Start()
    {
        input = new RebindJumping();
    }

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
            InputAction action = input.asset.FindAction("Interact");
            string key = action.GetBindingDisplayString(0).ToUpper();

            interactionInfo = text;
            InteractionText.GetComponent<TMP_Text>().text = "Press " + key + " to " + text;
        }
    }
}
