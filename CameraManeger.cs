using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CameraManeger : MonoBehaviour

{
    private Camera camera;
    private float cameraRotationSpeed = 5f;
    private float cameraMoveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MoveCamera();        
    }

    void RotateCamera()
    {
        float deltaMouseX = Input.GetAxis("Mouse X"); // �}�E�X��x�������̈ړ���
        float deltaMouseY = Input.GetAxis("Mouse Y"); // �}�E�X��y�������̈ړ���

        camera.transform.Rotate(new Vector3(-deltaMouseY, 0f, 0f));
        camera.transform.RotateAround(camera.transform.position, Vector3.up, deltaMouseX);
    }

    void MoveCamera()
    {
        var velocity = Vector3.zero; // �e�����̈ړ���
        var qua = camera.transform.rotation; // ��]�̏��
        if(Input.GetKey(KeyCode.W))
        {
            velocity.z = cameraMoveSpeed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            velocity.z = -cameraMoveSpeed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            velocity.x = -cameraMoveSpeed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            velocity.x = cameraMoveSpeed;
        }
        camera.transform.position += new Quaternion(0f, qua.y, qua.z, qua.w) * velocity;
    }
}