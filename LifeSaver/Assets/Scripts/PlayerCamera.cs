using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity = 5.0f; // ���������������� �������� ����
    private float rotationX = 0.0f;   // ���� �������� �� ��� X
    private float rotationY = 0.0f;   // ���� �������� �� ��� Y

    void Update()
    {
        // �������� �������� ����
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // ��������� ���� ��������
        rotationX -= mouseY; // ������� �� ��� X
        rotationY += mouseX; // ������� �� ��� Y

        // ������������ ���� �������� �� ��� X
        rotationX = Mathf.Clamp(rotationX, -40f, 40f);

        // ��������� ������� � ������
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
