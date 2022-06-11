using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioSource audio2;
    [SerializeField] private TMP_Text volumeTextValue2 = null;
    [SerializeField] private Slider volumeSlider2 = null;
    [SerializeField] private float defaultVolume2 = 1.0f;

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        float volume2 = volumeSlider2.value;
        AudioListener.volume = volume2;
        volumeTextValue2.text = volume2.ToString("F2");
    }

    public void VolumeApply2()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox2());
    }

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

    public IEnumerator ConfirmationBox2()
    {
        yield return new WaitForSeconds(2);

    }

    void Start()
    {
        audio2 = GetComponent<AudioSource>();
        audio2.Play();
    }

}