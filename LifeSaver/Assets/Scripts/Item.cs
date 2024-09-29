
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        Inventory inventory =FindObjectOfType<Inventory>();
        inventory.Add(gameObject);

    }
}
