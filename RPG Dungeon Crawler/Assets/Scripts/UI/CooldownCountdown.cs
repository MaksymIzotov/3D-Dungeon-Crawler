using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownCountdown : MonoBehaviour
{
    public static CooldownCountdown Instance;

    private void Awake()
    {
        Instance = this;
    }

    private float spellCooldownTimer;

    private Image img;
    private void Start()
    {
        img = GetComponentsInChildren<Image>()[1];       
    }

    private void Update()
    {
        if (img.fillAmount <= 0) { return; }
        Countdown();
    }

    private void Countdown()
    {
        img.fillAmount -= 1.0f / spellCooldownTimer * Time.deltaTime;
    }

    public void SetTimer(float time)
    {
        img.fillAmount = 1;
        spellCooldownTimer = time;
    }
}
