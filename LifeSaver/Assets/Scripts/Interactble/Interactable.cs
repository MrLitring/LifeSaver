using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact(params object[] insides)
    {
        throw new System.Exception("���� ��������������");
    }

    public virtual void Interact(GameObject obj)
    {
        throw new System.Exception("���� ��������������");
    }

    public virtual void Interact()
    {
        throw new System.Exception("���� ��������������");
    }
}
