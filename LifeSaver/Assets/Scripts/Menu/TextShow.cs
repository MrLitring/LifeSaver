using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextShow : MonoBehaviour
{
    private SceneWork sceneWork;
    
    
    
    public TextMeshProUGUI TextObject;
    public string StringName = string.Empty;


    private void Start()
    {
        sceneWork = SceneWork.Instance;
        if (TextObject == null) return;
        TextObject.text = sceneWork.GetString(StringName);
    }


}
