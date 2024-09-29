using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public KeyCode KeyCode = KeyCode.E;
    public int SlotIndex = 0;


    public Transform Camera;
    public float InteractionDistance = 3f;

    Ray ray = new Ray();

    private void Start()
    {
        Camera = transform.Find("Main Camera");
    }

    private void Update()
    {
        Ray ray = new Ray(Camera.transform.position, Camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * InteractionDistance, Color.white);

        RaycastHit hit;
        if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, InteractionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Debug.DrawRay(ray.origin, ray.direction * InteractionDistance, Color.green);

                if(Input.GetKey(this.KeyCode))
                    interactable.Interact();
            }

        }

        if(Input.GetKeyUp(KeyCode.Q))
        {
            Inventory inventory = FindObjectOfType<Inventory>();
            inventory.Remove(SlotIndex);
        }

    }

}
