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

    /*
     * recebe o objeto com a tag HealthBar
     * recebe o objeto Slider
     * colocar o valor do slider
     * recebe o objeto AudioSource
     * coloca o tempo a 0
     */
    void Start()
    {
        healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        slider = healthBarObject.GetComponent<Slider>();
        value = slider.value;

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;

        time = 0;
    }

    /*
     * atualiza o value com o valor do slider a cada frame 
     * e decrementa o tempo
     */
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

    /*
     * compare se o que entrou no trigger é um player 
     * se sim verifica se o tempo se encontra a zero se sim coloca o a 1
     * tira 10 ao value e ao slider
     * e toca um audioClip
     */
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

    /*
     * compare se o que entrou no trigger é um player 
     * se sim verifica se o tempo se encontra a zero se sim coloca o a 0
     * coloca a 0 o value e o slider
     * e toca um audioClip
     */
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

    /*
     * compare se o que entrou no trigger é um player 
     * se sim coloca o tempo a 0
     */
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            time = 0;
        }
    }

}
