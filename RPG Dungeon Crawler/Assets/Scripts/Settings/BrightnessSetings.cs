using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BrightnessSetings : MonoBehaviour
{
    [SerializeField] private CurrentSettings settings;

    private Volume volume;
    private ColorAdjustments brightness;

    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out brightness);

        SetupBrightness();
    }

    private void SetupBrightness()
    {
        brightness.postExposure.value = settings.brightness;
    }
}
