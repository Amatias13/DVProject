using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Variaveis
    public Slider slider;

    //Define a vida máxima do jogador, recebido por parametro
    public void setMaxHeath(int heath)
    {
        slider.maxValue = heath;
        slider.value = heath;
    }

    //Define a vida do jogador
    public void SetHeath(int health)
    {
        slider.value = health;
    }
}
