using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{ 
    public void SceneRestart()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneLoad(sceneIndex);
    }

    public void SceneLoad(int sceneIndex)
    {
        SceneWork sceneWork = SceneWork.Instance;

        sceneWork.Reset();
        sceneWork.SceneLoad();
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;

    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
