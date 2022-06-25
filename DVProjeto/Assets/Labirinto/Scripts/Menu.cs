using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    //Variaveis
    [SerializeField] private AudioSource audio2;
    [SerializeField] private TMP_Text volumeTextValue2 = null;
    [SerializeField] private Slider volumeSlider2 = null;
    [SerializeField] private float defaultVolume2 = 1.0f;

    //Ao iniciar, começa a musica e define os valores iniciais
    void Start()
    {
        audio2 = GetComponent<AudioSource>();
        audio2.Play();
        volumeTextValue2.text = "1.0";
        volumeSlider2.value = defaultVolume2;
    }

    //Ao clicar para sair, sai do jogo
    public void ExitButton()
    {
        Application.Quit();
    }

    //Define o som mediante do slider
    public void SetVolume()
    {
        float volume2 = volumeSlider2.value;
        AudioListener.volume = volume2;
        volumeTextValue2.text = volume2.ToString("F2");
    }

    //Define o volume nas settings internas
    public void VolumeApply2()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox2());
    }

    //Mete os valores com os default values
    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume2;
            volumeSlider2.value = defaultVolume2;
            volumeTextValue2.text = defaultVolume2.ToString("F2");
            VolumeApply2();
        }
    }

    //Apresenta a box por 2 segundos
    public IEnumerator ConfirmationBox2()
    {
        yield return new WaitForSeconds(2);

    }


    //Para a música
    public void StopMusic()
    {
        audio2.Stop();
    }

}