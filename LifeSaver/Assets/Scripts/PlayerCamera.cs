using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivityX = 400;
    public float sensitivityY = 400;


    private float rotationX = 0.0f;   // ���� �������� �� ��� X
    private float rotationY = 0.0f;   // ���� �������� �� ��� Y

    public Transform Orientation;

    void Update()
    {
        // �������� �������� ����
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        // ��������� ���� ��������
        rotationX -= mouseY;
        rotationY += mouseX;

        // ������������ ���� �������� �� ��� X
        rotationX = Mathf.Clamp(rotationX, -90, 90f);

        // ��������� ������� � ������
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        Orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
