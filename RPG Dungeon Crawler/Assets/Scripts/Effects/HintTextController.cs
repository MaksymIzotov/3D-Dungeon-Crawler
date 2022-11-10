using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintTextController : MonoBehaviour
{
    private GameObject player;
    private TMP_Text text;

    private Color textColor = new Color(255, 255, 255, 255);
    private float alpha = 0;

    private bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        SetupPlayer();
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (player == null) { SetupPlayer(); return; }

        Rotate();

        if (!isOn)
        {
            textColor.a = 0;
            text.color = textColor;
            return;
        }

        float dist = Vector3.Distance(transform.parent.position, player.transform.position);
        if (dist < 10)
        {
            alpha = ExtensionMethods.Remap(dist, 5, 10, 0, 1);
            textColor.a = alpha;
        }
        else
        {
            textColor.a = 1;
        }

        text.color = textColor;
    }

    private void Rotate()
    {
        transform.LookAt(player.transform);
    }

    private void SetupPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TurnOn() => isOn = true;
    public void TurnOff() => isOn = false;
}
