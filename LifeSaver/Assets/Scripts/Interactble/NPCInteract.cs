using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteract : Interactable
{
    public UnityEvent OnUse = new UnityEvent();

    public override void Interact(GameObject item)
    {
        item.SetActive(false);
        item.transform.SetParent(transform);

    }
}
