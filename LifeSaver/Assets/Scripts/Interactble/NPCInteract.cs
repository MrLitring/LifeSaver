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
            if (SceneWork.Instance.score < -100 ) SceneWork.Instance.score = -100;
            SceneWork.Instance.FalseAnswer.Add(item.GetComponent<Item>().itemName);
        }
        else
        {
            SceneWork.Instance.score += SceneWork.Instance.scoreStep;

            if (SceneWork.Instance.score > 100) SceneWork.Instance.score = 100;
            SceneWork.Instance.TrueAnswer.Add(item.GetComponent<Item>().itemName);
        }

    }
}
