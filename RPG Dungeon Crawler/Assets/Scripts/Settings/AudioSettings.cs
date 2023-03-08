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

    }

    public void SaveSettings()
    {
        audioMixer.SetFloat("Volume", volumeSlider.value);
    }

    public void LoadData()
    {

    }
}
