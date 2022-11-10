using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.SimpleLUT;
using TMPro;

public class VideoSettingsApply : MonoBehaviour
{
    public enum Type { Slider, Dropdown, Text }

    [System.Serializable]
    public struct Settings {
        public string name;
        public Type type;
        public Slider slider;
        public Dropdown dropdown;
        public TMP_Text text;
    }

    [SerializeField] private List<Settings> SettingsProperties;

    [SerializeField] private CurrentSettings settings;
    [SerializeField] private SimpleLUT cameraSettings;

    private void Start()
    {
        //LoadAllSettings();
    }

    public void ApplyBrightness()
    {
        foreach(Settings item in SettingsProperties)
        {
            if(item.name == "brightness")
            {
                float brightness = item.slider.value;

                cameraSettings.Brightness = brightness;
                settings.brightness = brightness;

                PlayerPrefs.SetFloat(item.name, brightness);
            }
        }
    }

    private void LoadAllSettings()
    {
        foreach(Settings item in SettingsProperties)
        {
            switch (item.type)
            {
                case Type.Slider:
                    if (!PlayerPrefs.HasKey(item.name))
                    {
                        PlayerPrefs.SetFloat(item.name, item.slider.value);
                    }
                    else
                    {
                        float value = PlayerPrefs.GetFloat(item.name);
                        item.slider.value = value;
                    }
                    break;
                case Type.Dropdown:

                    break;
                case Type.Text:

                    break;
            }
        }
    }
}
