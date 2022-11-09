using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintTextController : MonoBehaviour
{
    GameObject player;
    TMP_Text text;

    Color textColor = new Color(255,255,255,255);
    float alpha = 255;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        Rotate();

        float dist = Vector3.Distance(transform.parent.position, player.transform.position);
        if(dist < 10)
        {
            Debug.Log(alpha);
            alpha = ExtensionMethods.Remap(dist, 5, 10, 0, 0.5f);
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
}
