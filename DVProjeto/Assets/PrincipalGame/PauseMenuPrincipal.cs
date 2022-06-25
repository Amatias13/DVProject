using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuPrincipal : MonoBehaviour
{
    //Variaveis
    public bool gameIsPaused;
    [SerializeField] private GameObject pauseMenuUI;
    private AudioSource audioSource;
    private DayScript dayScript;
    private ClockUI clockUi;

    //Inicializa as variaveis
    void Start()
    {
        gameIsPaused = false;
        clockUi = FindObjectOfType<ClockUI>();
        dayScript = FindObjectOfType<DayScript>();
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
    }

    //Retoma o jogo, o tempo e o cursor volta a aparecer
    public void Resume()
    {
        dayScript.isPlaying = true;
        clockUi.ResumeTime();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    //Para o jogo, o tempo e o cursor desaparece
    public void Pause()
    {
        dayScript.isPlaying = false;
        clockUi.StopTime();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    //Ao ir para o menu, o jogo retoma
    public void MainMenu()
    {
        gameIsPaused = false;
        dayScript.isPlaying = true;
        clockUi.ResumeTime();
        Time.timeScale = 1f;
    }
}
