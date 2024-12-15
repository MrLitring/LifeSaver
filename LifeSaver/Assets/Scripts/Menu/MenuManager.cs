using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject PlayModeUI;
    public GameObject EditModeUI;

    void Start()
    {
        if (PlayModeUI == null || EditModeUI == null) return;

        if (SceneWork.Instance.isEditMode == true)
        {
            PlayModeUI.gameObject.SetActive(false);
            EditModeUI.gameObject.SetActive(true);
        }
        else
        {
            PlayModeUI.gameObject.SetActive(true);
            EditModeUI.gameObject.SetActive(false);
        }
    }
}
