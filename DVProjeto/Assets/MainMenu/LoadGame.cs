using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private GameObject load;
    public void Start()
    {
        int status = PlayerPrefs.GetInt("GamesStatus", 0);

        if (status == 0)
        {
            load.SetActive(false);
        }
    }

    public void Load()
    {
        SceneManager.LoadScene(5);
    }
}
