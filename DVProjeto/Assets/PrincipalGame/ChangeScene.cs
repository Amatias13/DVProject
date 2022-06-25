using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Variaveis

    //Faz a transição da cena para a cena recebida por parametro
    public void MoveToScene(int sceneID)
    {
        var data = PlayerPrefs.GetString("GameData", "{}");
        GameData gameData = JsonUtility.FromJson<GameData>(data);
        var json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", json);

        if (sceneID == -1)
        {
            int randomNumber = Random.Range(2, 5);
            SceneManager.LoadScene(randomNumber);
        } else SceneManager.LoadScene(sceneID);
    }
}
