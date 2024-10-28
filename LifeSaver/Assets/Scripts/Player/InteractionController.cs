using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class InteractionController : MonoBehaviour
{
    public int InventoryKey = 1;
    public PlayerInventory playerInventory = null;
    public Transform Hand;
    public Transform DropHand;


    public Transform Camera;
    public float InteractionDistance = 3f;

    public TextMeshProUGUI helpText;


    private void Start()
    {
        Camera = transform.Find("Main Camera");
        playerInventory = FindObjectOfType<PlayerInventory>();
        InventoryKey = 0;
    }

    private void Update()
    {
        SlotController();
        Interactable interactable = InteractbleSearch();
        if (interactable != null) 
            InteractableAction(interactable);


        if (Input.GetKeyUp(KeyboardSettings.Drop))
            playerInventory.Drop(InventoryKey, DropHand);
    }

    private void InteractableAction(Interactable interactable)
    {
        if (Input.GetKeyUp(KeyboardSettings.Interactble))
            if (interactable != null)
            {
                if (interactable.GetComponent<NPCInteract>())
                {
                    GameObject item = playerInventory.GetItem(InventoryKey, true);
                    if (item != null)
                        interactable.Interact(item);
                }
                else if (interactable.GetComponent<Item>())
                    interactable.GetComponent<Interactable>().Interact(InventoryKey, interactable.gameObject);

                else
                    interactable.Interact();
            }


       
    }


    private void SlotController()
    {
        if (Input.GetKeyUp(KeyboardSettings.Alpha1))
            InventoryKey = 0;
        else if (Input.GetKeyUp(KeyboardSettings.Alpha2))
            InventoryKey = 1;
        else if (Input.GetKeyUp(KeyboardSettings.Alpha3))
            InventoryKey = 2;
        else if (Input.GetKeyUp(KeyboardSettings.Alpha4))
            InventoryKey = 3;
        else if (Input.GetKeyUp(KeyboardSettings.Alpha5))
            InventoryKey = 4;
    }

    private Interactable InteractbleSearch()
    {
        Ray ray = new Ray(Camera.transform.position, Camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * InteractionDistance, Color.white);
        Interactable interactable = null;

        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, InteractionDistance))
        {
            interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Debug.DrawRay(ray.origin, ray.direction * InteractionDistance, Color.green);
            }
        }

        if (helpText != null)
        {
            string text = "";
            if (interactable != null)
            {
                if (interactable.GetComponent<Item>())
                {
                    text = $"Нажмите на {KeyboardSettings.Interactble.ToString()} ," +
                        $" чтобы поднять {interactable.GetComponent<Item>().itemName}";
                }
                else if (interactable.GetComponent<NPCInteract>())
                {
                    text = $"Нажмите на {KeyboardSettings.Interactble.ToString()} ," +
                        $" чтобы применить на {interactable.GetComponent<NPCInteract>().name}";
                }
            }

            helpText.text = text;
        }

        return interactable;
    }
}
