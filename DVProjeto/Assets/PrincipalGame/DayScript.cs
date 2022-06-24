using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayScript : MonoBehaviour
{
    private float time;
    private int day;

    private int numberOfSmallHouse;
    private int numberOfBigHouse;

    private int numberOfPlantation;
    private int numberOfBigPlantation;

    private int numberOfPowerTower;
    private int numberOfBigPowerTower;

    private int numberOfWaterTower;
    private int numberOfBigWaterTower;

    private int numberOfResourceTower;
    private int numberOfBigResourceTower;

    private DataManager dataManager;
    private ResourcesTexts resourcesTexts;

    [SerializeField] private GameObject popUpMessage;

    void Start()
    {
        time = 10;
        day = PlayerPrefs.GetInt("days", 1);

        numberOfSmallHouse = 0;
        numberOfBigHouse = 0;

        numberOfPlantation = 0;
        numberOfBigPlantation = 0;

        numberOfPowerTower = 0;
        numberOfBigPowerTower = 0;

        numberOfWaterTower = 0;
        numberOfBigWaterTower = 0;

        numberOfResourceTower = 0;
        numberOfBigResourceTower = 0;

        dataManager = gameObject.GetComponent<DataManager>();
        resourcesTexts = GetComponent<ResourcesTexts>();
    }

    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (PlayerPrefs.GetInt("GamesStatus", 0) != 0)
            {
                numberOfSmallHouse = GameObject.FindGameObjectsWithTag("SmallHouse").Length;
                numberOfBigHouse = GameObject.FindGameObjectsWithTag("BigHouse").Length;

                numberOfPlantation = GameObject.FindGameObjectsWithTag("Plantation").Length;
                numberOfBigPlantation = GameObject.FindGameObjectsWithTag("bigPlantation").Length;

                numberOfPowerTower = GameObject.FindGameObjectsWithTag("PowerTower").Length;
                numberOfBigPowerTower = GameObject.FindGameObjectsWithTag("bigPowerTower").Length;

                numberOfWaterTower = GameObject.FindGameObjectsWithTag("WaterTower").Length;
                numberOfBigWaterTower = GameObject.FindGameObjectsWithTag("bigWaterTower").Length;

                numberOfResourceTower = GameObject.FindGameObjectsWithTag("ResourceTower").Length;
                numberOfBigResourceTower = GameObject.FindGameObjectsWithTag("bigResourceTower").Length;

                int amoutOfPower = dataManager.gameData.power + (numberOfSmallHouse * -15) + (numberOfBigHouse * -20) + (numberOfPlantation * -5) + (numberOfBigPlantation * -25) + (numberOfPowerTower * 50) + (numberOfBigPowerTower * 100)
                    + (numberOfWaterTower * -10) + (numberOfBigWaterTower * -20) + (numberOfResourceTower * -30) + (numberOfBigResourceTower * -55);

                int amoutOfWater = dataManager.gameData.water + (dataManager.gameData.people * -2) + (numberOfSmallHouse * -10) + (numberOfBigHouse * -20) + (numberOfPlantation * -20) + (numberOfBigPlantation * -40)
                    + (numberOfWaterTower * 40) + (numberOfBigWaterTower * 100) + (numberOfResourceTower * -10) + (numberOfBigResourceTower * -20);

                int amoutOfFood = dataManager.gameData.food + (dataManager.gameData.people * -3) + (numberOfPlantation * 15) + (numberOfBigPlantation * 40) + (numberOfResourceTower * -10) + (numberOfBigResourceTower * -20);

                int amoutOfResources = dataManager.gameData.resources + (numberOfPlantation * 30) + (numberOfBigPlantation * 60) + (numberOfResourceTower * 150) + (numberOfBigResourceTower * 300);

                List<int> amounts = new List<int>();
                amounts.Add(amoutOfPower);
                amounts.Add(amoutOfWater);
                amounts.Add(amoutOfFood);
                amounts.Add(amoutOfResources);

                int negAmount = 0;

                if (day > 0)
                {
                    for (int i = 0; i < amounts.Count; i++)
                    {
                        if (amounts[i] < 0)
                        {
                            negAmount += amounts[i];
                        }
                    }
                }

                int amoutOfPeople = dataManager.gameData.people + (numberOfSmallHouse * 2) + (numberOfBigHouse * 3) + (int)(negAmount * 0.1 * day);


                dataManager.gameData.power = amoutOfPower;
                resourcesTexts.PowerText(amoutOfPower);

                dataManager.gameData.water = amoutOfWater;
                resourcesTexts.WaterText(amoutOfWater);

                dataManager.gameData.resources = amoutOfResources;
                resourcesTexts.ResourcesText(amoutOfResources);

                dataManager.gameData.food = amoutOfFood;
                resourcesTexts.FoodText(amoutOfFood);


                dataManager.gameData.people = amoutOfPeople;
                if (dataManager.gameData.people < 0)
                {
                    resourcesTexts.PeopleText(0);

                    PlayerPrefs.SetInt("GamesStatus", 0);
                    PlayerPrefs.SetInt("days", 1);

                    popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().GameOver("Game Over!");
                    GameObject.FindObjectOfType<ClockUI>().StopTime();
                    dataManager.GameOver();

                    GameObject.FindGameObjectWithTag("BuildButton").SetActive(false);
                    GameObject.FindGameObjectWithTag("MiniGameButton").SetActive(false);
                    GameObject.FindGameObjectWithTag("Objects").SetActive(false);
                    
                }
                else
                {
                    resourcesTexts.PeopleText(amoutOfPeople);
                    time = 10;
                    day++;
                    PlayerPrefs.SetInt("days", day);
                }
            }

        }
    }
}
