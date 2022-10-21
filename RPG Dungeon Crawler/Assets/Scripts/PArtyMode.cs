using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SimpleLUT;

public class PArtyMode : MonoBehaviour
{
    SimpleLUT sl;

    private float value = 0;
    private void Start()
    {
        sl = GetComponent<SimpleLUT>();

        StartCoroutine(ChangeColor());
    }

    private void FixedUpdate()
    {
        sl.Hue = Mathf.Lerp(sl.Hue, value, 0.01f);
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            value = Random.Range(0, 360);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
