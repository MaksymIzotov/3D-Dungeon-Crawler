using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsProperties", menuName = "Settings/CurrentSettings", order = 1)]
public class CurrentSettings : ScriptableObject
{
    public float sensitivity = 1f;
    public float brightness = 0f;

    public bool isPlaying;
    public bool isTutorial;
    public bool isLost;
}
