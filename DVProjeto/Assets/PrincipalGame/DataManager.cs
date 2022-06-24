using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private GameObject diamondsText;
    [SerializeField] private GameObject powerText;
    [SerializeField] private GameObject waterText;
    [SerializeField] private GameObject resourcesText;
    [SerializeField] private GameObject foodText;


    public GameData gameData;

    void Awake()
    {
        var data = PlayerPrefs.GetString("GameData", "{}");
        gameData = JsonUtility.FromJson<GameData>(data);


        diamondsText.GetComponent<TextMeshProUGUI>().text = "" + gameData.diamonds;
        powerText.GetComponent<TextMeshProUGUI>().text = "" + gameData.power;
        waterText.GetComponent<TextMeshProUGUI>().text = "" + gameData.water;
        resourcesText.GetComponent<TextMeshProUGUI>().text = "" + gameData.resources;
        foodText.GetComponent<TextMeshProUGUI>().text = "" + gameData.food;

        Debug.Log(gameData.placedList);
        Debug.Log(gameData.food);
    }

    public void AddToMap(Vector2 vector2, GameObject gameObject)
    {
        gameData.placedList.Add(new MapData(vector2, gameObject));
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
