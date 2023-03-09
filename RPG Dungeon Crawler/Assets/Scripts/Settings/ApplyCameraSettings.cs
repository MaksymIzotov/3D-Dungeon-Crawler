using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ApplyCameraSettings : MonoBehaviour
{
    private Volume volume;
    private ColorAdjustments brightness;

    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out brightness);

        Setup();
    }

    private void Setup()
    {
        if (PlayerPrefs.HasKey("BrightnessPreference"))
        {
            brightness.postExposure.value = PlayerPrefs.GetFloat("BrightnessPreference");
        }
        else
        {
            brightness.postExposure.value = 1;
        }

        if (PlayerPrefs.HasKey("ContrastPreference"))
        {
            brightness.contrast.value = PlayerPrefs.GetFloat("ContrastPreference");
        }
        else
        {
            brightness.contrast.value = 0;
        }
    }
}
