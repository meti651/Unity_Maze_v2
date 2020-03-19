using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public string MouseXInputName, MouseYInputName;
    public float MouseSensitivity;
    public GameObject Player;

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(MouseXInputName) * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(MouseYInputName) * MouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotation(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotation(90);
        }

        Vector3 direction = Player.transform.forward;

        transform.Rotate(Vector3.left * mouseY);
        Player.transform.Rotate(Vector3.up * mouseX);
        Rigidbody playerPhisycs = Player.GetComponent<Rigidbody>();
        playerPhisycs.rotation = Quaternion.Euler(playerPhisycs.rotation.eulerAngles + Vector3.up * mouseX);
    }

    private void ClampXAxisRotation(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

}
