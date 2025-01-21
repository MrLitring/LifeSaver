using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public interface IGameLoader
{ 
    void Load();
}


public class GameLoader : MonoBehaviour
{
    [Tooltip("��������� ������� ��� ��������� ��������")]
    public UnityEvent NeedLoad = new UnityEvent();

    private void Awake()
    {
        NeedLoad.Invoke();
    }
}
