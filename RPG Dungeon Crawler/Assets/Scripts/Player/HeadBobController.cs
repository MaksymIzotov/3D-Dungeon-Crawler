using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool isEnable = true;

    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float frequency = 10;

    [SerializeField] private Transform cam;
    [SerializeField] private Transform camHolder;

    private float toggleSpeed = 0.8f;
    private Vector3 startPos;
    private PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        startPos = cam.localPosition;
    }

    private void Update()
    {
        if (!enabled) { return; }

        CheckMotion();
        ResetPositon();
        cam.LookAt(FocusTarget());
    }

    private void CheckMotion()
    {
        float speed = controller.GetMovement().magnitude;

        if (speed < toggleSpeed) return;
        if (!controller.GetIsGrounded()) return;

        float mult = controller.isRunning ? 1.5f : 1;
        PlayMotion(FootStepMotion(mult));
    }

    private void PlayMotion(Vector3 motion)
    {
        cam.localPosition += motion;
    }

    private void ResetPositon()
    {
        if (cam.localPosition == startPos) { return; }
        cam.localPosition = Vector3.Lerp(cam.localPosition, startPos, 1 * Time.deltaTime);
    }

    private Vector3 FootStepMotion(float mult)
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency * mult) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2 * mult) * amplitude * 2;
        return pos;
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + camHolder.localPosition.y, transform.position.z);
        pos += camHolder.forward * 15;
        return pos;
    }
}
