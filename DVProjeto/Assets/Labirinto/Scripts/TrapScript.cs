using UnityEngine;
using UnityEngine.UI;

public class TrapScript : MonoBehaviour
{
    private GameObject healthBarObject;
    private Slider slider;
    private float value;
    private AudioSource audioSource;
    private AudioClip audioClip;

    /*
     * recebe o objeto com a tag HealthBar
     * recebe o objeto Slider
     * colocar o valor do slider
     * recebe o objeto AudioSource
     */
    void Start()
    {
        healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        slider = healthBarObject.GetComponent<Slider>();
        value = slider.value;

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
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
            value -= 10f;
            slider.value = value;
            if(slider.value != 0)
            {
                audioSource.PlayOneShot(audioClip);
            }
            
        }
    }

    /*
     * atualiza o value com o valor do slider a cada frame 
     */
    void Update()
    {
        value = slider.value;
    }


}
