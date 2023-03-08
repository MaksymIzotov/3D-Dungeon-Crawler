using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [Space(20)]

    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        LoadData();
    }

    public void LoadSettingsMenu()
    {
        if (PlayerPrefs.HasKey("Volume"))
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        else
            volumeSlider.value = 0;
    }

    public void SaveSettings()
    {
        audioMixer.SetFloat("Volume", volumeSlider.value);

        SavePrefs();
    }

    private void SavePrefs()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Volume"))
            audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
        else
            audioMixer.SetFloat("Volume", 0);
    }
}
