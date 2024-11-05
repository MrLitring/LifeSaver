using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SunColorChange : MonoBehaviour
{
    [Header("Time Settings")]
    [Range(0, 24)]
    public float timeOfDay;

    public Light sunLight;
    public Color moonLight;
    public Color noonColor;
    public Color eveningColor;

    private void Update()
    {
        searchLight();
        SetRotate();
    }

    private void searchLight()
    {
        if (sunLight == null)
            sunLight = GetComponent<Light>();
    }


    private void SetRotate()
    {
        float angle = (timeOfDay / 24f) * 360f;
        sunLight.transform.rotation = Quaternion.Euler(angle - 90, 0, 0);


    }
}
