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

    [SerializeField] TMP_Text healthText;

    public void UpdateHealth(float hp)
    {
        healthText.text = hp.ToString("F0");
    }
}
