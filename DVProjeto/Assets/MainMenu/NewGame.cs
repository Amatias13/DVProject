using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{

    public void NewGameM()
    {
        int status = PlayerPrefs.GetInt("GamesStatus", 0);

        if (status == 0)
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            PlayerPrefs.SetInt("GamesStatus", 0);
            SceneManager.LoadScene(5);
        }
    }
}
