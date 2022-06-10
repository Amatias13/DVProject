using TMPro;
using UnityEngine;

public class Begin : MonoBehaviour
{
    [SerializeField] private GameObject timeObject;
    [SerializeField] private float timeLeft;
    private TextMeshProUGUI time;
    private bool asStart;
    // Start is called before the first frame update
    void Start()
    {
        time = timeObject.GetComponent<TextMeshProUGUI>(); 
        time.text = "" + timeLeft;
        asStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(asStart && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            time.text = "" + Mathf.Floor(timeLeft * 100) / 100f; ;
        }
        if(timeLeft < 0)
        {
            timeLeft = 0;
            time.text = "" + timeLeft;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            asStart = true;
        }
    }
}
