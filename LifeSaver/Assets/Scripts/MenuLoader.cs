using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public void SceneLoad(int sceneIndex)
    {
        if (sceneIndex >= 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            throw new System.Exception("Индекс сцены не назначен на: " + gameObject.name.ToString());
        }
    }

}
