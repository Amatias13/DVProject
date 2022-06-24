using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{

    private float timeRemaining = 1;
    [SerializeField] private GameObject popUp;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            popUp.SetActive(false);
        }
    }

    public void setText(string text)
    {
        GetComponent<TextMeshProUGUI>().text = text;
        popUp.SetActive(true);
    }
    
}
