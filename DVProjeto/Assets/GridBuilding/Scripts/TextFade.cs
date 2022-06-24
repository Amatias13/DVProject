using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFade : MonoBehaviour
{
    private float duration = 20;
    public bool type;
    public string text;
    void Update()
    {
        gameObject.SetActive(true);
        if(Time.time > duration)
            Destroy(gameObject);

        Color color;
        if (type)
            color = Color.green;
        else
            color = Color.red;

        float ratio = Time.time / duration;
        color.a = Mathf.Lerp(1, 0, ratio);
        GetComponent<TextMeshPro>().text = text;
        GetComponent<TextMeshPro>().color = color;
    }
}
