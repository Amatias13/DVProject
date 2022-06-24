using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    [SerializeField] private GameObject timeObject;
    [SerializeField] private GameObject dieObject;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject healthBarObject;
    public float timeLeft;
    [SerializeField] private string level;

    private Movement movement;
    private Slider slider;
    private TextMeshProUGUI time;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private bool asStart;
    private bool played;
    private bool end;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            asStart = true;
        }
    }

    public void Pause()
    {
        asStart = false;
    }

    public void Resume()
    {
        asStart = true;
    }

    public bool isDead()
    {
        if (slider.value == 0)
        {
            return true;
        }
        return false;
    }

    public void EndGame()
    {
        end = true;
        slider.value = 0;
    }

    

}
