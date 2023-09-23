using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate2 : MonoBehaviour
{
    public GameObject screamer1;
    public GameObject screamer2;
    public GameObject playerCamera;
    float xRot = 90f;
    public float sensitive = 500f;

    void MouseMove()
    {
        Cursor.lockState = CursorLockMode.None;
        xRot += Input.GetAxis("Mouse X") * sensitive * Time.deltaTime;
        xRot = Mathf.Clamp(xRot, 20f, 160f);
        transform.rotation = Quaternion.Euler(0f, xRot, 0f);
    }

    void Update()
    {
        if (playerCamera.activeSelf == true && screamer1.activeSelf == false && screamer2.activeSelf == false)
        {
            MouseMove();
        }
    }
}
