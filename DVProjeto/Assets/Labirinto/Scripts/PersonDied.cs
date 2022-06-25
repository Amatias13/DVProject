using UnityEngine.SceneManagement;
using UnityEngine;

public class PersonDied : MonoBehaviour
{
    /*
     * recebe a informação do jogo retirando uma pessoa pois esta morreu no mini-jogo 
     * retira o estado do curso 
     * apos 1 segundo e meio volta para o jogo principal
     */
    public void PersonM()
    {
        var data = PlayerPrefs.GetString("GameData", "{}");
        GameData gameData = JsonUtility.FromJson<GameData>(data);

        gameData.people -= 1;
        float time = 1.5f; 

        var json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", json);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        while(time > 0)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                SceneManager.LoadScene(5);
            }
        }
        
    }
}
