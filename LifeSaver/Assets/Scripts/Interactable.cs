using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact(params object[] insides)
    {
        throw new System.Exception("Нету взаимодействия");
    }
}
