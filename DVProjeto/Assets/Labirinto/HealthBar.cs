using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHeath(int heath)
    {
        slider.maxValue = heath;
        slider.value = heath;
    }
    
    public void SetHeath(int health)
    {
        slider.value = health;
    }
}
