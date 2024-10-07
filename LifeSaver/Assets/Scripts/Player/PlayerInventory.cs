using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform InventoryParent;
    private GameObject[] inventorySlots = new GameObject[5];

    private void Start()
    {
        if (InventoryParent == null)
            InventoryParent = transform.Find("Inventory");
    }


    public void Add(int slotIndex, GameObject obj)
    {
        slotIndex--;

        if (inventorySlots[slotIndex] == null)
        {
            inventorySlots[slotIndex] = obj;
            obj.transform.SetParent(InventoryParent);
            obj.SetActive(false);
        }

    }

    public void Remove(int slotIndex)
    {
    }

    public void Drop(int slotIndex, Transform dropPosition)
    {
        slotIndex--;

        if (inventorySlots[slotIndex] != null)
        {
            GameObject obj = null;
            obj = inventorySlots[slotIndex];
            obj.transform.SetParent(null);
            obj.transform.position = dropPosition.position;
            obj.SetActive(true);

            inventorySlots[slotIndex] = null;
        }
    }


    public GameObject[] GetInventory()
    { return inventorySlots; }
}
