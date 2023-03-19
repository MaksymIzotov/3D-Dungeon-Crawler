using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle isFullscreenToggle;
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Slider contrastSlider;

    [SerializeField] private Volume volume;
    private ColorAdjustments brightness;

    Resolution[] resolutions;

    private void Start()
    {
        volume.profile.TryGet(out brightness);
    }

    public void SetBrightness()
    {
        brightness.postExposure.value = brightnessSlider.value;

        PlayerPrefs.SetFloat("BrightnessPreference", brightnessSlider.value);
    }

    public void SetContrast()
    {
        brightness.contrast.value = contrastSlider.value;

        PlayerPrefs.SetFloat("ContrastPreference", contrastSlider.value);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, false);
        qualityDropdown.value = qualityIndex;

        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            qualityDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("QualitySettingPreference"));
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualitySettingPreference"), false);
        }
        else
        {
            qualityDropdown.SetValueWithoutNotify(1);
            QualitySettings.SetQualityLevel(1, false);
        }

        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            resolutionDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("ResolutionPreference"));
        }
        else
        {
            resolutionDropdown.SetValueWithoutNotify(currentResolutionIndex);
        }

        isFullscreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);

        if (PlayerPrefs.HasKey("BrightnessPreference"))
        {
            brightnessSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("BrightnessPreference"));
        }
        else
        {
            brightnessSlider.SetValueWithoutNotify(1);
        }

        if (PlayerPrefs.HasKey("ContrastPreference"))
        {
            contrastSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("ContrastPreference"));
        }
        else
        {
            contrastSlider.SetValueWithoutNotify(0);
        }
    }

    public void UpdateSettingsMenu()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        int currentResolutionIndex = 0;


        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }


        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }
}
