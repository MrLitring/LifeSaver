using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCTargets : MonoBehaviour
{
    public string TableName = "Scenario";
    public List<NPCInteract> list = new List<NPCInteract>();

    private SceneWork sceneWork;


    private void Start()
    {
        sceneWork = SceneWork.Instance;

        for (int i = 0; i < sceneWork.collisions.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (sceneWork.collisions[i] == list[j].ID)
                {
                    list[j].isTargets = true;

                    for (int k = 0; k < sceneWork.items.Count; k++)
                        list[j].items.Add(sceneWork.items[k]);
                }
            }
        }
    }
}
