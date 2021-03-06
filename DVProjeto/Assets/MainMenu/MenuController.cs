using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{

    
    [SerializeField] private AudioSource audio;

    [Header("Levels to Load")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private GameObject confirmationPrompt = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Levels to Load")]
    public string newGameLevel;
    public string levelToLoad;

    /*
     *Permite sair da aplica??o
     */
    public void ExitButton()
    {
        Application.Quit();
    }

    /*
     *Permite atualizar o volume dos sons do jogo
     */
    public void SetVolume()
    {
        float volume = volumeSlider.value;
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("F2");
    }

    
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    /*
     *Permite colocar o volume default
     */
    public void ResetButton(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("F2");
            VolumeApply();
        }
    }

    
    public IEnumerator ConfirmationBox()
    {
        
        yield return new WaitForSeconds(2);
        
    }

    /*
     *Permite iniciar o volume dos sons do jogo com um valor default;
     */
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
        volumeTextValue.text = "1.0";
        volumeSlider.value = defaultVolume;
    }

}
