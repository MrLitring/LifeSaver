using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextVisible : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int Seconds = 10;

    private void Start()
    {
        textMeshPro.text = SceneWork.Instance.SceneDescription;

        StartCoroutine(Hide());
    }


    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(Seconds);

        gameObject.SetActive(false);
    }
}
