using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    //Variaveis
    [SerializeField] private GameObject timeObject;
    [SerializeField] private GameObject dieObject;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject healthBarObject;
    [SerializeField] private string level;
    private Movement movement;
    private Slider slider;
    private TextMeshProUGUI time;
    private AudioSource audioSource;
    private AudioClip audioClip;
    public float timeLeft;
    private bool asStart;
    private bool played;
    private bool end;

    //Ao iniciar, define as variaveis mediante do nível
    void Start()
    {
        movement = FindObjectOfType<Movement>();
        time = timeObject.GetComponent<TextMeshProUGUI>();
        slider = healthBarObject.GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;

        time.text = "" + timeLeft;
        asStart = false;
        played = false;
        end = false;

        if (level.Equals("facil"))
        {
            healthBarObject.SetActive(false);
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("TimeGroup"))
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    //O contador reduz e se chegar ao fim, morre
    void Update()
    {
        if (!end)
        {
            if (asStart && timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                time.text = "" + Mathf.Floor(timeLeft * 100) / 100f; ;
            }
            if (slider.value == 0 || timeLeft < 0)
            {
                Dead();

                timeLeft = 0;
                time.text = "" + timeLeft;
            }
        }

    }

    //Morre, e volta para o menu quando carregar no botão
    void Dead()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        movement.Kill();
        dieObject.SetActive(true);
        backButton.SetActive(true);
        slider.value = 0;
        if (!played)
        {
            played = true;
            audioSource.PlayOneShot(audioClip);
        }

    }

    //Ao começar, ativa para o jogo começar
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            asStart = true;
        }
    }

    //Ao pausar, o jogo para
    public void Pause()
    {
        asStart = false;
    }

    //Ao retomar, o jogo retoma
    public void Resume()
    {
        asStart = true;
    }

    //Verifica se a vida do utilizador é 0 ou não
    public bool isDead()
    {
        if (slider.value == 0)
        {
            return true;
        }
        return false;
    }

    //Termina o jogo
    public void EndGame()
    {
        end = true;
    }

    //Determina se o jogo acabou
    public bool GetEndGame()
    {
        return end ;
    }

}
