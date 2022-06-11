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
    [SerializeField] private float defaultSensitivity = 100.0f;
    private PlayerCam playerCam;

    // Start is called before the first frame update
    public void SetSensitivity()
    {
        float sensitivity = sensitivitySlider.value;
        playerCam.SetSense(sensitivity);
        sensitivityTextValue.text = sensitivity.ToString("F2");
    }

    public void SensitivityApply()
    {
        PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);
    }

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

    void Start()
    {
        playerCam = FindObjectOfType<PlayerCam>();
        sensitivitySlider.value = defaultSensitivity;
        sensitivityTextValue.text = defaultSensitivity.ToString("F2");
        playerCam.SetSense(defaultSensitivity);


    }


}
