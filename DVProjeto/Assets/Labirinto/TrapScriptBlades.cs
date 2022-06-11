using UnityEngine;
using UnityEngine.UI;

public class TrapScriptBlades : MonoBehaviour
{
    private GameObject healthBarObject;
    private Slider slider;
    private float value;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private float time;

    void Start()
    {
        healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        slider = healthBarObject.GetComponent<Slider>();
        value = slider.value;

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;

        time = 0;
    }

    void Update()
    {
        value = slider.value;
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (time == 0)
            {
                time = 1f;
            }
            
            value -= 10f;
            slider.value = value;

            if (slider.value != 0)
            {
                audioSource.PlayOneShot(audioClip);
            }

        }
    }

    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (time == 0)
            {
                value = 0f;
                slider.value = value;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            time = 0;
        }
    }

}
