using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SensitivitySlider : MonoBehaviour
{
    
    [SerializeField] private TMP_Text sensitivityTextValue = null;
    [SerializeField] private Slider sensitivitySlider = null;
    private float defaultSensitivity = 100.0f;
    private PlayerCam playerCam;

    /**
     * Permite atualizar a sensibilidade do cursor
     * e atualiza o valor mostrado ao utilizador
     */
    public void SetSensitivity()
    {
        float sensitivity = sensitivitySlider.value;
        playerCam.SetSense(sensitivity);
        sensitivityTextValue.text = sensitivity.ToString("F2");
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
    }

   
    public void SensitivityApply()
    {
        PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);
    }

    /**
     * Permite colocar um valor de defeito na sesibilidade do cursor do utilizador 
     * e atualiza o valor mostrado ao utilizador
     */
    public void ResetButton(string MenuType)
    {
        if (MenuType == "Sensitivity")
        {
            playerCam.SetSense(defaultSensitivity);
            sensitivityTextValue.text = defaultSensitivity.ToString("F2");
            sensitivitySlider.value = defaultSensitivity;
            SensitivityApply();
        }
    }

    /**
     * Permite obter a sensibilidade do cursor que esta associada ao utilizador
     * colocar esse valor de sensibilidade na camera que o utilizador visualiza e atalizar o valor que é mostrado ao utilizador
     */
    void Start()
    {
        playerCam = FindObjectOfType<PlayerCam>();
        sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity", defaultSensitivity);
        sensitivityTextValue.text = PlayerPrefs.GetFloat("sensitivity", defaultSensitivity).ToString("F2");
        playerCam.SetSense(PlayerPrefs.GetFloat("sensitivity", defaultSensitivity));
    }


}
