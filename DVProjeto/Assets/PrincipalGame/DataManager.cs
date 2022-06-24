using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private GameObject diamondsText;
    [SerializeField] private GameObject powerText;
    [SerializeField] private GameObject waterText;
    [SerializeField] private GameObject resourcesText;
    [SerializeField] private GameObject foodText;


    private GameData gameData;

    void Awake()
    {
        var data = PlayerPrefs.GetString("GameData", "{}");
        gameData = JsonUtility.FromJson<GameData>(data);


        diamondsText.GetComponent<TextMeshProUGUI>().text = "" + gameData.diamonds;
        powerText.GetComponent<TextMeshProUGUI>().text = "" + gameData.power;
        waterText.GetComponent<TextMeshProUGUI>().text = "" + gameData.water;
        resourcesText.GetComponent<TextMeshProUGUI>().text = "" + gameData.resources;
        foodText.GetComponent<TextMeshProUGUI>().text = "" + gameData.food;

        
    }

    public void SetMap(Dictionary<Vector2, GameObject> placedList)
    {
        gameData.placedList =  placedList;
    }


    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(gameData);
        Debug.Log(json);
        PlayerPrefs.SetString("GameData", json);
    }
}
