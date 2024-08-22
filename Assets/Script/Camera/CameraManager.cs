using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 100.0f;
    private float xRotation = 0f;
    [SerializeField]
    private float clampXRotateMin = -45.0f;
    [SerializeField]
    private float clampXRotateMax = 45.0f;
    private Vector2 _mousePos;

    [SerializeField]
    private Transform _playerHead;
    [SerializeField]
    private Transform _playerBody;

    public void MousePos(InputAction.CallbackContext context)
    {
        _mousePos = context.ReadValue<Vector2>();
    }

    private void RotateCam()
    {
        float mouseX = _mousePos.x * _mouseSensitivity * Time.deltaTime;
        float mouseY = _mousePos.y * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, clampXRotateMin, clampXRotateMax);

        if (_playerHead != null)
            _playerHead.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        else
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (_playerBody != null)
            _playerBody.Rotate(Vector3.up * mouseX);
        else
            transform.Rotate(Vector3.up * mouseX);
    }
    private void Update()
    {
        RotateCam();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}