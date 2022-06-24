using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpScript : MonoBehaviour
{

    private float timeRemaining = 1;
    private bool isRunning = true;
    [SerializeField] private GameObject popUp;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;


        }
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            if (isRunning)
            {
                popUp.SetActive(false);
            }
        }


    }

    public void setText(string text)
    {
        if (isRunning)
        {
            timeRemaining = 1;
            popUp.SetActive(true);
            GetComponent<TextMeshProUGUI>().text = text;
        }

    }

    public void GameOver(string text)
    {
        isRunning = false;
        popUp.SetActive(true);
        GetComponent<TextMeshProUGUI>().text = text;
        popUp.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }
}
