using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObjectController : MonoBehaviour
{
    Material texture;

    private float alpha;
    public float fadeSpeed = 1f;
    public float rotationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 0;

        texture = GetComponentInChildren<MeshRenderer>().material;
        texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);

        if (alpha >= 1) { return; }
        alpha += fadeSpeed * Time.deltaTime;

        texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, alpha);
    }
}
