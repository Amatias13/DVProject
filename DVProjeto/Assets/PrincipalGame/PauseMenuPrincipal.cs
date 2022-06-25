using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuPrincipal : MonoBehaviour
{
    public bool gameIsPaused;
    [SerializeField] private GameObject pauseMenuUI;
    private AudioSource audioSource;
    private DayScript dayScript;
    private ClockUI clockUi;

    void Start()
    {
        gameIsPaused = false;
        clockUi = FindObjectOfType<ClockUI>();
        dayScript = FindObjectOfType<DayScript>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        dayScript.isPlaying = true;
        clockUi.ResumeTime();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        dayScript.isPlaying = false;
        clockUi.StopTime();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MainMenu()
    {
        gameIsPaused = false;
        dayScript.isPlaying = true;
        clockUi.ResumeTime();
        Time.timeScale = 1f;
    }
}
