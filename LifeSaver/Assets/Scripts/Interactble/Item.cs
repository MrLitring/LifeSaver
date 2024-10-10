using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public int ID = -1;
    public string itemName = "Item";
    public string description = "";



    public override void Interact(params object[] insides)
    {
        if (insides.Length > 0)
        {
            PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
            inventory.Add((int)insides[0], gameObject);
        }
    }
}
