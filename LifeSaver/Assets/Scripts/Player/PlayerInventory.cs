using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform InventoryParent;
    public GameObject[] InventorySlotsShow = new GameObject[5];
    public Color ColorDeselect = Color.white;
    public Color ColorSelected = Color.white;


    private GameObject[] inventorySlots = new GameObject[5];



    private void Start()
    {
        if (InventoryParent == null)
            InventoryParent = transform.Find("Inventory");
    }


    public void Add(int slotIndex, GameObject obj)
    {
        if (inventorySlots[slotIndex] == null)
        {
            inventorySlots[slotIndex] = obj;
            obj.transform.SetParent(InventoryParent);
            obj.SetActive(false);

            Debug.Log(slotIndex.ToString());
            VisibleInventorySlots(slotIndex, obj.GetComponent<Item>().itemName.Substring(0,1));
        }
        
    }

    public void Remove(int slotIndex)
    {
        GameObject item = inventorySlots[slotIndex];
        inventorySlots[slotIndex] = null;

        item.transform.SetParent(null);

        UnVisibleInventorySlots(slotIndex);
    }

    public void Drop(int slotIndex, Transform dropPosition)
    {
        if (inventorySlots[slotIndex] != null)
        {
            GameObject obj = null;
            obj = inventorySlots[slotIndex];
            obj.transform.SetParent(null);
            obj.transform.position = dropPosition.position;
            obj.SetActive(true);

            inventorySlots[slotIndex] = null;

            
            UnVisibleInventorySlots(slotIndex);
        }

    }


    public GameObject[] GetInventory()
    { return inventorySlots; }

    public GameObject GetItem(int index, bool isRemove = false)
    {
        if (inventorySlots[index] != null)
        {
            GameObject item = inventorySlots[index];
            if (isRemove == true)
                Remove(index);

            return item;
        }
        else return null;
    }


    public void ShowSlotActive(int index)
    {
        for (int slotIndex = 0; slotIndex < InventorySlotsShow.Length; slotIndex++)
        {
            InventorySlotsShow[slotIndex].gameObject.GetComponent<UnityEngine.UI.Image>().color = ColorDeselect;

            if(slotIndex == index)
                InventorySlotsShow[slotIndex].gameObject.GetComponent<UnityEngine.UI.Image>().color = ColorSelected;
        }
    }


    private void VisibleInventorySlots(int index, string name ="")
    {
        TextMeshProUGUI text = null;

        text = InventorySlotsShow[index].gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();

        if (text == null) return;

        text.text = name;


    }

    private void UnVisibleInventorySlots(int index)
    {
        TextMeshProUGUI text = null;

        text = InventorySlotsShow[index].gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();

        if (text == null) return;

        text.text = "";

    }
}
