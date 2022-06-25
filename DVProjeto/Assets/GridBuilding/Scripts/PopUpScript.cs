using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpScript : MonoBehaviour
{

    //Variaveis
    private float timeRemaining = 2;
    private bool isRunning = true;
    [SerializeField] private GameObject popUp;

    //Contador, quando chegar ao fim esconde o popup 
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

    //Define o texto e apresenta o popup
    public void setText(string text)
    {
        if (isRunning)
        {
            timeRemaining = 2;
            popUp.SetActive(true);
            GetComponent<TextMeshProUGUI>().text = text;
        }

    }

    //Apresenta o popup com botão
    public void GameOver(string text)
    {
        isRunning = false;
        popUp.SetActive(true);
        GetComponent<TextMeshProUGUI>().text = text;
        popUp.transform.GetChild(1).gameObject.SetActive(true);
    }

    //Onclick, carrega a cena do menu principal
    public void Back()
    {
        SceneManager.LoadScene(1);
    }
}
