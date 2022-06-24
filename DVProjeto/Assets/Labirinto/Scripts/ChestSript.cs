using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestSript : MonoBehaviour
{
    private GameObject messagesObject;
    private Animator animator;
    private GameObject message;
    private float time;
    private float timeOfMessage;
    private bool open;
    private List<string> messages = new List<string>();
    private AudioSource audioSource;
    private AudioClip audioClip;

    // Update is called once per frame
    void Start()
    {
        messages.Add("Water");
        messages.Add("Power");
        messages.Add("Wood");
        messages.Add("Food");

        messagesObject = GameObject.FindGameObjectWithTag("MessagesObject");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;

        time = 0f;
        timeOfMessage = 0f;
        open = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                animator.Play("Fantasy_Polygon_Chest_Animation");
                time = 2.5f;
                transform.GetChild(3).gameObject.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                if (!open)
                {
                    GetReward();
                }
                
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        transform.GetChild(3).gameObject.SetActive(false);
    }

    void Update()
    {
        if (time != 0)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                Destroy(gameObject);
            }
        }

        if (timeOfMessage != 0)
        {
            
            timeOfMessage -= Time.deltaTime;
            if (timeOfMessage < 0)
            {
                message.SetActive(false);
                open = false;
            }
        }

    }

    void GetReward()
    {
        open = true;

        int typeOfReward = Random.Range(0, 3);
        int amoutOfReward = Random.Range(50, 100);

        var data = PlayerPrefs.GetString("GameData", "{}");
        GameData gameData = JsonUtility.FromJson<GameData>(data);

        if (typeOfReward == 0)
        {
            Debug.Log(gameData.water);
            gameData.water += amoutOfReward;
        }
        else if (typeOfReward == 1)
        {
            Debug.Log(gameData.power);
            gameData.power += amoutOfReward;
        } 
        else if (typeOfReward == 2)
        {
            Debug.Log(gameData.resources);
            gameData.resources += amoutOfReward;
        }
        else if (typeOfReward == 3)
        {
            Debug.Log(gameData.food);
            gameData.food += amoutOfReward;
        }

        if(SceneManager.GetActiveScene().buildIndex != 2)
        {
            GameObject.FindObjectOfType<Begin>().timeLeft += 10;
        }

        var json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", json);

        message = messagesObject.transform.GetChild(typeOfReward).gameObject;

        message.SetActive(true);

        TextMeshProUGUI textMessages = message.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        timeOfMessage = 2f;

        textMessages.text = "YOU GET: " + amoutOfReward;

    }

}
