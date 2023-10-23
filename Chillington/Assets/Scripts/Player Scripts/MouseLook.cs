using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public Camera cam;

    public float defaultFOV = 60;
    public float aimFOV = 40;
    public float unAimFOV = 60f;
    public float lerpTime = 1f;
    //might need to add the value to variable in unity UI

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (Input.GetMouseButton(1))
        {
            AimDownSight();
        }
        else
        {
            defaultFOV = Mathf.Lerp(defaultFOV, unAimFOV, lerpTime);
            cam.fieldOfView = defaultFOV;
        }
    }

    private void AimDownSight()
    {
        defaultFOV = Mathf.Lerp(defaultFOV, aimFOV, lerpTime);
        cam.fieldOfView = defaultFOV;
    }
}
