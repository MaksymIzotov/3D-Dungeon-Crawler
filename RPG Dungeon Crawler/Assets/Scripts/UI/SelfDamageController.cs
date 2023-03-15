using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelfDamageController : MonoBehaviour
{
    public float lifetime;
    public float speed;

    TMP_Text text;

    public float colorChangeStep;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(LoseFade());
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    IEnumerator LoseFade()
    {
        for (float i = 1; i >= 0; i -= colorChangeStep * Time.deltaTime)
        {
            // set color with i as alpha
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            yield return null;
        }

        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }
}
