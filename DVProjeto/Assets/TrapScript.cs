using UnityEngine;
using UnityEngine.UI;

public class TrapScript : MonoBehaviour
{
    private GameObject healthBarObject;
    private Slider slider;
    private float value;

    void Start()
    {
        healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        slider = healthBarObject.GetComponent<Slider>();
        value = slider.value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            value -= 10f;
            slider.value = value;
        }
    }
}
