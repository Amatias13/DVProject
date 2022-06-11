using UnityEngine;
using UnityEngine.UI;

public class TrapScript : MonoBehaviour
{
    private GameObject healthBarObject;
    private Slider slider;
    private float value;
    private AudioSource audioSource;
    private AudioClip audioClip;

    void Start()
    {
        healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        slider = healthBarObject.GetComponent<Slider>();
        value = slider.value;

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            value -= 10f;
            slider.value = value;
            if(slider.value != 0)
            {
                audioSource.PlayOneShot(audioClip);
            }
            
        }
    }

    void Update()
    {
        value = slider.value;
    }


}
