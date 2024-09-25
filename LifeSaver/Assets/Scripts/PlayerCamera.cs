using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity = 5.0f; // Чувствительность движения мыши
    private float rotationX = 0.0f;   // Угол поворота по оси X
    private float rotationY = 0.0f;   // Угол поворота по оси Y

    void Update()
    {
        // Получаем движение мыши
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Обновляем углы поворота
        rotationX -= mouseY; // Поворот по оси X
        rotationY += mouseX; // Поворот по оси Y

        // Ограничиваем угол поворота по оси X
        rotationX = Mathf.Clamp(rotationX, -40f, 40f);

        // Применяем поворот к камере
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
