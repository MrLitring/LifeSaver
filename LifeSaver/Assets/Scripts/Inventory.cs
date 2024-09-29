using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform InventoryParent;
    public int[] slots = new int[6];



    public void Add(GameObject obj)
    {
        int slotIndex = searchEmptySlot();
        if(FillCount() >= 6) return;

        slots[slotIndex] = 1;
        obj.transform.SetParent(InventoryParent);
        obj.SetActive(false);
    }

    public void Remove(int slotIndex)
    {
        Transform obj = InventoryParent.GetChild(slotIndex);

        if (obj == null)
            return;

        slots[slotIndex] = 0;
        Destroy(obj.gameObject);
        SlotResets();
    }

    public void Drop(int slotIndex)
    {
        Transform obj = InventoryParent.GetChild(slotIndex);

        if (obj == null)
            return;

        slots[slotIndex] = 0;
        obj.transform.SetParent(null);
        obj.gameObject.SetActive(true);
        SlotResets();
    }

    public int FillCount()
    {
        int count = 0;
        for (int i = 0; i < 6; i++)
            if (slots[i] != 0)
                count++;

        return count;
    }

    private int searchEmptySlot()
    {
        int slotIndex = 0;
        for(int i = 0;i < 6;i++)
            if (slots[i] == 0) return i;

        return slotIndex;
    }

    private void SlotResets()
    {
        Debug.Log("Работа");
        for(int i = 0; i < 5; i++)
        {
            if (slots[i] == 0)
            {
                slots[i] = 1;
                slots[i + 1] = 0;
                Debug.Log("закончил:" + i);
            }
        }
        Debug.Log("зак");
    }
}
