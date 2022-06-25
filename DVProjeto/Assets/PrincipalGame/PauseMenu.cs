using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Variaveis
    public bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    private Begin begin;
    private AudioSource audioSource;

    //Inicializa as variaveis
    void Start()
    {
        begin = FindObjectOfType<Begin>();
        audioSource = GetComponent<AudioSource>();
    }

    //A cada segundo, se carregar no ESC, mete em pausa. Se estiver morto, para a música
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

    //Retoma o jogo, o tempo e o cursor volta a aparecer
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        begin.Resume();
    }

    //Para o jogo, o tempo e o cursor desaparece
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        begin.Pause();
    }

    //Ao ir para o menu, o jogo retoma
    public void MainMenu()
    {
        gameIsPaused = false;
        begin.Resume();
        Time.timeScale = 1f;
    }
}
