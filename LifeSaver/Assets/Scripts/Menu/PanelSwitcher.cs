using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public List<GameObject> panels;



    public void SwitchPanel(int num)
    {
        if (!PanelsNotNull(num)) return;

        foreach (GameObject go in panels)
            go.SetActive(false);

        panels[num].SetActive(true);
    }

    private bool PanelsNotNull(int ind)
    {
        if (panels.Count == 0) return false;
        else if (panels.Count - 1< ind) return false;
        else return true;
    }
}
