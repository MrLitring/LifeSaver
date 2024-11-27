using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteract : Item
{
    public bool isTargets = false;
    public List<int> items = new List<int>();


    public override void Interact(GameObject item)
    {
        item.SetActive(false);
        item.transform.SetParent(transform);

        if (isTargets == false)
        {
            SceneWork.Instance.score -= SceneWork.Instance.scoreStep;
        }
        else
            SceneWork.Instance.score += SceneWork.Instance.scoreStep;

    }
}
