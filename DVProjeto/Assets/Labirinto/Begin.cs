using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    [SerializeField] private GameObject timeObject;
    [SerializeField] private GameObject dieObject;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject healthBarObject;
    [SerializeField] private float timeLeft;

    private Movement movement;
    private Slider slider;
    private TextMeshProUGUI time;
    private bool asStart;

    void Start()
    {
        movement = FindObjectOfType<Movement>();
        time = timeObject.GetComponent<TextMeshProUGUI>();
        slider = healthBarObject.GetComponent<Slider>();
        time.text = "" + timeLeft;
        asStart = false;
    }

    void Update()
    {
        if(asStart && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            time.text = "" + Mathf.Floor(timeLeft * 100) / 100f; ;
        }
        if(slider.value == 0 || timeLeft < 0)
        {
            Dead();

            timeLeft = 0;
            time.text = "" + timeLeft;
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
}
