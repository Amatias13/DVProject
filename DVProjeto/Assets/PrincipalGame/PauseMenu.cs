using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    private Begin begin;
    private AudioSource audioSource;

    void Start()
    {
        begin = FindObjectOfType<Begin>();
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
        if (begin.isDead())
        {
            audioSource.Stop();
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        begin.Resume();
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        begin.Pause();
    }

    public void MainMenu()
    {
        gameIsPaused = false;
        begin.Resume();
        Time.timeScale = 1f;
    }
}
