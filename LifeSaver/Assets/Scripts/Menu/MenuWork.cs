using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuWork : MonoBehaviour
{
    public GameObject menu;

    private void Start()
    {
        CursorSetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (menu.activeSelf == false)
            {
                menu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
            if (menu.activeSelf == false)
                CursorSetActive(true);
        if (Input.GetKeyUp(KeyCode.LeftAlt))
            CursorSetActive(false);
    }

    private void CursorSetActive(bool active)
    {
        Cursor.visible = active;
        if(!active)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
