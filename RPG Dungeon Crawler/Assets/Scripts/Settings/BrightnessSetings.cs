using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SimpleLUT;

public class BrightnessSetings : MonoBehaviour
{
    [SerializeField] private CurrentSettings settings;
    SimpleLUT sl;

    private void Start()
    {
        sl = GetComponent<SimpleLUT>();

        SetupBrightness();
    }

    private void SetupBrightness()
    {
        sl.Brightness = settings.brightness;
    }
}
