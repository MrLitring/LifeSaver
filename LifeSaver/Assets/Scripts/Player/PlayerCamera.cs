using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivityX = 400;
    public float sensitivityY = 400;


    private float rotationX = 0.0f;   // Угол поворота по оси X
    private float rotationY = 0.0f;   // Угол поворота по оси Y

    public Transform Orientation;

    void Update()
    {
        // Получаем движение мыши
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        // Обновляем углы поворота
        rotationX -= mouseY;
        rotationY += mouseX;

        // Ограничиваем угол поворота по оси X
        rotationX = Mathf.Clamp(rotationX, -90, 90f);

        // Применяем поворот к камере
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        Orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
