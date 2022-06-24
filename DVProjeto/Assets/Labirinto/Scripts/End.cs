using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject endObject;

    private float time;
    private Movement movement;
    private Begin begin;
    private Menu menu;

    void Start()
    {
        time = 0;
        movement = FindObjectOfType<Movement>();
        begin = FindObjectOfType<Begin>();
        menu = FindObjectOfType<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (begin.isDead())
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else if(time < 0)
            {
                SceneManager.LoadScene(5);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endObject.SetActive(true);
            time = 1f;
            movement.Kill();
            begin.Pause();
            begin.EndGame();
            menu.StopMusic();

            var data = PlayerPrefs.GetString("GameData", "{}");
            GameData gameData = JsonUtility.FromJson<GameData>(data);

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                gameData.water += 10;
                gameData.food += 10;
                gameData.resources += 50;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                gameData.water += 75;
                gameData.food += 50;
                gameData.resources += 150;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                gameData.water += 150;
                gameData.food += 100;
                gameData.resources += 300;
                gameData.diamonds += 3;
            }

            var json = JsonUtility.ToJson(gameData);
            PlayerPrefs.SetString("GameData", json);

            PlayerPrefs.SetInt("days", PlayerPrefs.GetInt("days", 0) + 1);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
