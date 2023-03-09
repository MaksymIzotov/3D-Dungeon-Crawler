using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle isFullscreenToggle;

    Resolution[] resolutions;

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        SaveSettings();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        SaveSettings();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, false);
        qualityDropdown.value = qualityIndex;

        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));

        PlayerPrefs.Save();
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            qualityDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("QualitySettingPreference"));
        }
        else
        {
            qualityDropdown.SetValueWithoutNotify(1);
        }
        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            resolutionDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("ResolutionPreference"));
        }
        else
        {
            resolutionDropdown.SetValueWithoutNotify(currentResolutionIndex);
        }
        if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            isFullscreenToggle.SetIsOnWithoutNotify(Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference")));
        }
        else
        {
            isFullscreenToggle.SetIsOnWithoutNotify(true);
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
