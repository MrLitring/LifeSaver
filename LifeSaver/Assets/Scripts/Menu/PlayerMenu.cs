using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject HUD;
    public GameObject TaskUI;
    public GameObject AnswerUI;



    private void Start()
    {
        CursorSetActive(false);
        Menu.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Menu.activeSelf == false)
                Pause();
            else
                Resume();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
            if (Menu.activeSelf == false)
                CursorSetActive(true);
        if (Input.GetKeyUp(KeyCode.LeftAlt))
            CursorSetActive(false);

    }


    public void Pause()
    {
        Menu.SetActive(true);
        HUD.SetActive(false);

        CursorSetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        Menu.SetActive(false);
        HUD.SetActive(true);

        CursorSetActive(false);
        Time.timeScale = 1f;

    }

    public void SceneRestart()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneLoad(sceneIndex);
        
    }

    public void ExitMainMenu()
    {
        SceneLoad(0);

    }

    public void Quit()
    {
        Application.Quit();

    }

    public void AnwerUI()
    {
        Pause();
        Menu.transform.Find("Buttons").gameObject.SetActive(false);
        AnswerUI.SetActive(true);
        AnswerUI.GetComponent<AnswerCalculation>().Show();
    }

    public void SceneLoad(int SceneIndex)
    {
        SceneWork.Instance.Reset();
        SceneWork.Instance.SceneLoad();
        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1f;

    }



    private void CursorSetActive(bool active)
    {
        Cursor.visible = active;
        if (!active)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

    }
}
