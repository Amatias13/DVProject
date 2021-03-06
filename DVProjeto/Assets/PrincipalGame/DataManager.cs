using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //Variaveis
    public GameData gameData;
    private ResourcesTexts resourcesTexts;
    private bool over;

    //Ao iniciar, se for a primeira vez, come?a com os recursos default e mete os textos. Se n?o for a primeira vez, d? load do progresso do utilizador
    void Awake()
    {
        resourcesTexts = GetComponent<ResourcesTexts>();

        int status = PlayerPrefs.GetInt("GamesStatus", 0);
        // status == 1 ja come?ou status == 0 ainda nao 

        if (status == 0)
        {
            gameData.people = 10;
            gameData.diamonds = 0;
            gameData.power = 100;
            gameData.water = 100;
            gameData.resources = 500;
            gameData.food = 100;
        }
        else
        {
            var data = PlayerPrefs.GetString("GameData", "{}");
            gameData = JsonUtility.FromJson<GameData>(data);
        }

        PlayerPrefs.SetInt("GamesStatus", 1);

        resourcesTexts.DiamondsText(gameData.diamonds);
        resourcesTexts.PowerText(gameData.power);
        resourcesTexts.WaterText(gameData.water);
        resourcesTexts.ResourcesText(gameData.resources);
        resourcesTexts.FoodText(gameData.food);
        resourcesTexts.PeopleText(gameData.people);

        over = false;
    }

    //Adiciona ? lista o objeto e a sua posi??o na grid
    public void AddToMap(Vector2 vector2, GameObject gameObject)
    {
        gameData.placedList.Add(new MapData(vector2, gameObject));
    }

    //Atualiza a lista com o novo objecto numa determinada posi??o
    public void UpdateMap(Vector2 vector2, GameObject gameObject)
    {
        for (int x = 0; x < gameData.placedList.Count; x++)
        {
            if (gameData.placedList[x].vector2 == vector2)
            {
                gameData.placedList[x].gameObject = gameObject;
            }
        }
    }

    //Grava a pontua??o
    private void OnDestroy()
    {
        if (over == false) 
        { 
            SaveScore(); 
        }
    }

    //Termina que o jogo acabou
    public void GameOver()
    {
        over = true;
    }

    //Guarda a pontua??o do jogador
    public void SaveScore()
    {
        var json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", json);
        PlayerPrefs.SetInt("GamesStatus", 1);
        PlayerPrefs.SetInt("days", PlayerPrefs.GetInt("days"));
    }
}
