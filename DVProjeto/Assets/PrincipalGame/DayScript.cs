using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayScript : MonoBehaviour
{
    private float time;
    private int numberOfSmallHouse;
    private int numberOfBigHouse;
    private DataManager dataManager;
    private ResourcesTexts resourcesTexts;

    void Start()
    {
        time = 5;
        numberOfSmallHouse = 0;
        numberOfBigHouse = 0;

        dataManager = gameObject.GetComponent<DataManager>();
        resourcesTexts = GetComponent<ResourcesTexts>();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfSmallHouse = GameObject.FindGameObjectsWithTag("SmallHouse").Length;
        numberOfBigHouse = GameObject.FindGameObjectsWithTag("BigHouse").Length;

        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            double numberOf = dataManager.gameData.power - (dataManager.gameData.power * 0.2);
            dataManager.gameData.power = (int)numberOf;
            resourcesTexts.PowerText((int)numberOf);

            numberOf = dataManager.gameData.water - (dataManager.gameData.water * 0.2);
            dataManager.gameData.water = (int)numberOf;
            resourcesTexts.WaterText((int)numberOf);

            numberOf = dataManager.gameData.resources - (dataManager.gameData.resources * 0.2);
            dataManager.gameData.resources = (int)numberOf;
            resourcesTexts.ResourcesText((int)numberOf);

            numberOf = dataManager.gameData.food - (dataManager.gameData.food * 0.2);
            dataManager.gameData.food = (int)numberOf;
            resourcesTexts.FoodText((int)numberOf);

            numberOf = dataManager.gameData.people - (dataManager.gameData.people * 0.2);
            dataManager.gameData.people = (int)numberOf;
            resourcesTexts.PeopleText((int)numberOf);

            time = 5;
        }
    }
}
