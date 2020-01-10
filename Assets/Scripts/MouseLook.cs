﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 100f;

    private float _xRotation = 0f;

    private Transform _playerBody;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;

        _playerBody = transform.parent;
    }

    // Update is called once per frame
    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(new Vector3(_xRotation, 0f, 0f));
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
