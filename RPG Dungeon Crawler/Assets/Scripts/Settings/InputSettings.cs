using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSettings : MonoBehaviour
{
    public CurrentSettings currentSettings;

    [SerializeField] private Slider sensSlider;

    private void Awake()
    {
        LoadSettings();
    }

    public void SetSensitivity(){
        currentSettings.sensitivity = sensSlider.value;

        PlayerPrefs.SetInt("Sensitivity", (int)sensSlider.value);
    }

    public void LoadSettings()
    {
        if(PlayerPrefs.HasKey("Sensitivity"))
        {
            int sens = PlayerPrefs.GetInt("Sensitivity");
            sensSlider.SetValueWithoutNotify(sens);
            currentSettings.sensitivity = sens;
        }
        else
        {
            int sens = 10;
            sensSlider.SetValueWithoutNotify(sens);
            currentSettings.sensitivity = sens;
        }
    }
}
