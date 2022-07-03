using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextController : MonoBehaviour
{
    public float lifetime;
    public float speed;

    GameObject player;
    TMP_Text text;

    Color transparent = new Color(0,0,0,0);
    public float colorChangeStep;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<TMP_Text>();
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.LookAt(player.transform);

        text.color = Color.Lerp(text.color, transparent, colorChangeStep * Time.deltaTime);
    }
}
