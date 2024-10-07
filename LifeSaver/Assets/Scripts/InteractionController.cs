using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public int InventoryKey = 1;
    public PlayerInventory inventory = null;
    public Transform Hand;
    public Transform DropHand;


    public Transform Camera;
    public float InteractionDistance = 3f;



    private void Start()
    {
        Camera = transform.Find("Main Camera");
        inventory = FindObjectOfType<PlayerInventory>();
        InventoryKey = 1;
    }

    private void Update()
    {
        SlotController();
        Interactable interactable = InteractbleSearch();

        if (Input.GetKeyUp(KeyboardSettings.Interactble))
            if(interactable != null)
                interactable.Interact(InventoryKey);

        if (Input.GetKeyUp(KeyboardSettings.Drop))
                inventory.Drop(InventoryKey, DropHand);
    }


    private void SlotController()
    {
        if (Input.GetKeyUp(KeyboardSettings.Alpha1))
            InventoryKey = 1;
        else if (Input.GetKeyUp(KeyboardSettings.Alpha2))
            InventoryKey = 2;
        else if (Input.GetKeyUp(KeyboardSettings.Alpha3))
            InventoryKey = 3;
        else if (Input.GetKeyUp(KeyboardSettings.Alpha4))
            InventoryKey = 4;
        else if (Input.GetKeyUp(KeyboardSettings.Alpha5))
            InventoryKey = 5;
    }

    private Interactable InteractbleSearch()
    {
        Ray ray = new Ray(Camera.transform.position, Camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * InteractionDistance, Color.white);

        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, InteractionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Debug.DrawRay(ray.origin, ray.direction * InteractionDistance, Color.green);
                return interactable;
            }
        }

        return null;
    }
}
