using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{

    [SerializeField] private Tile tilePrefab;
    [SerializeField] private GameObject hospitalPrefab;
    [SerializeField] private GameObject smallHousePrefab;
    [SerializeField] private GameObject bigHousePrefab;
    [SerializeField] private GameObject plantationPrefab;
    [SerializeField] private GameObject centralTowerPrefab;
    [SerializeField] private GameObject waterTowerPrefab;
    [SerializeField] private GameObject resourceTowerPrefab;
    [SerializeField] private Transform camera;
    [SerializeField] private int width, height;
    [SerializeField] private float money;
    [SerializeField] private Button btnHouses, btnHospital;
    private Boolean isShowing;
    private Boolean editMode;

    private GameObject choosen;
    private DataManager dataManager;
    private ResourcesTexts resourcesTexts;

    private Dictionary<Vector2, GameObject> placedList;
    private Dictionary<Vector2, Tile> tiles;
    private int hospitalCost = 250;
    private int houseCost = 100;

    private void Start()
    {
        isShowing = false;
        editMode = false;
        choosen = smallHousePrefab;
        placedList = new Dictionary<Vector2, GameObject>();
        dataManager = gameObject.GetComponent<DataManager>();
        resourcesTexts = gameObject.GetComponent<ResourcesTexts>();
        GenerateGrid();
    }

    public void GenerateGrid()
    {

        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset, new Vector2(x, y), this);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        camera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        camera.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);

        List<MapData> list = dataManager.gameData.placedList;

        for (int x = 0; x < list.Count; x++)
        {
            if (list[x] != null)
            {
                GameObject obj = Instantiate(list[x].gameObject, list[x].vector2, Quaternion.identity);
                placedList[list[x].vector2] = obj;
            }
        }
    }

    public void onMapClick(Vector2 pos)
    {
        if (editMode)
        {
            if (!placedList.ContainsKey(pos))
            {
                if (choosen.CompareTag("Hospital"))
                    if ((money - hospitalCost) >= 0)
                    {
                        GameObject obj = Instantiate(choosen, pos, Quaternion.identity);
                        placedList[pos] = obj;
                        money -= hospitalCost;
                        dataManager.AddToMap(pos, choosen);
                    }
                    else Debug.Log("Não há dinheiro");

                if (choosen.CompareTag("SmallHouse"))
                    if ((dataManager.gameData.power - 15 >= 0) && (dataManager.gameData.water - 10 >= 0) && (dataManager.gameData.resources - 100 >= 0))
                    {
                        GameObject obj = Instantiate(choosen, pos, Quaternion.identity);
                        placedList[pos] = obj;

                        dataManager.gameData.power -= 15;
                        dataManager.gameData.water -= 10;
                        dataManager.gameData.resources -= 100;

                        resourcesTexts.PowerText(dataManager.gameData.power);
                        resourcesTexts.WaterText(dataManager.gameData.water);
                        resourcesTexts.ResourcesText(dataManager.gameData.resources);

                        dataManager.AddToMap(pos, choosen);
                    }
                    else Debug.Log("Não tem recursos suficientes");

                if (choosen.CompareTag("Plantation"))
                    if ((dataManager.gameData.power - 5 >= 0) && (dataManager.gameData.water - 20 >= 0) && (dataManager.gameData.resources - 50 >= 0))
                    {
                        GameObject obj = Instantiate(choosen, pos, Quaternion.identity);
                        placedList[pos] = obj;

                        dataManager.gameData.power -= 5;
                        dataManager.gameData.water -= 20;
                        dataManager.gameData.resources -= 50;

                        resourcesTexts.PowerText(dataManager.gameData.power);
                        resourcesTexts.WaterText(dataManager.gameData.water);
                        resourcesTexts.ResourcesText(dataManager.gameData.resources);

                        dataManager.AddToMap(pos, choosen);
                    }
                    else Debug.Log("Não tem recursos suficientes");

                if (choosen.CompareTag("PowerTower"))
                    if ((dataManager.gameData.resources - 70 >= 0))
                    {
                        GameObject obj = Instantiate(choosen, pos, Quaternion.identity);
                        placedList[pos] = obj;

                        dataManager.gameData.resources -= 70;

                        resourcesTexts.ResourcesText(dataManager.gameData.resources);

                        dataManager.AddToMap(pos, choosen);
                    }
                    else Debug.Log("Não tem recursos suficientes");

                if (choosen.CompareTag("WaterTower"))
                    if ((dataManager.gameData.power - 10 >= 0) && (dataManager.gameData.resources - 50 >= 0))
                    {
                        GameObject obj = Instantiate(choosen, pos, Quaternion.identity);
                        placedList[pos] = obj;

                        dataManager.gameData.power -= 10;
                        dataManager.gameData.resources -= 50;

                        resourcesTexts.PowerText(dataManager.gameData.power);
                        resourcesTexts.ResourcesText(dataManager.gameData.resources);

                        dataManager.AddToMap(pos, choosen);
                    }
                    else Debug.Log("Não tem recursos suficientes");

                if (choosen.CompareTag("ResourceTower"))
                    if ((dataManager.gameData.power - 30 >= 0) && (dataManager.gameData.water - 10 >= 0) && (dataManager.gameData.food - 10 >= 0) && (dataManager.gameData.resources - 100 >= 0))
                    {
                        GameObject obj = Instantiate(choosen, pos, Quaternion.identity);
                        placedList[pos] = obj;

                        dataManager.gameData.resources -= 50;
                        dataManager.gameData.water -= 10;

                        resourcesTexts.ResourcesText(dataManager.gameData.resources);
                        resourcesTexts.WaterText(dataManager.gameData.water);

                        dataManager.AddToMap(pos, choosen);
                    }
                    else Debug.Log("Não tem recursos suficientes");
            }
            else
            {
                //UPGRADES

                GameObject temp = placedList[pos];

                if (temp.CompareTag("SmallHouse"))
                {
                    if ((money - 300) >= 0)
                    {
                        Destroy(temp);
                        GameObject super = bigHousePrefab;
                        GameObject obj = Instantiate(super, pos, Quaternion.identity);
                        placedList[pos] = obj;
                        dataManager.UpdateMap(pos, super);
                        money -= 300;
                    }
                }

                if (temp.CompareTag("Plantation"))
                {
                    if ((dataManager.gameData.power - 25 >= 0) && (dataManager.gameData.water - 20 >= 0) && (dataManager.gameData.diamonds - 10 >= 0))
                    {
                        dataManager.gameData.power -= 25;
                        dataManager.gameData.water -= 20;
                        dataManager.gameData.diamonds -= 10;

                        resourcesTexts.PowerText(dataManager.gameData.power);
                        resourcesTexts.WaterText(dataManager.gameData.water);
                        resourcesTexts.DiamondsText(dataManager.gameData.diamonds);

                        placedList[pos].tag = "bigPlantation";
                        dataManager.UpdateMap(pos, placedList[pos]);
                    }
                }

                if (temp.CompareTag("PowerTower"))
                {
                    if ((dataManager.gameData.resources - 130 >= 0) && (dataManager.gameData.diamonds - 10 >= 0))
                    {
                        dataManager.gameData.resources -= 130;
                        dataManager.gameData.diamonds -= 10;

                        resourcesTexts.ResourcesText(dataManager.gameData.resources);
                        resourcesTexts.DiamondsText(dataManager.gameData.diamonds);

                        placedList[pos].tag = "bigCentralPower";
                        dataManager.UpdateMap(pos, placedList[pos]);
                    }
                }

                if (temp.CompareTag("WaterTower"))
                {
                    if ((dataManager.gameData.power - 20 >= 0) && (dataManager.gameData.resources - 150 >= 0) && (dataManager.gameData.diamonds - 10 >= 0))
                    {
                        dataManager.gameData.power -= 20;
                        dataManager.gameData.resources -= 150;
                        dataManager.gameData.diamonds -= 10;

                        resourcesTexts.PowerText(dataManager.gameData.power);
                        resourcesTexts.ResourcesText(dataManager.gameData.resources);
                        resourcesTexts.DiamondsText(dataManager.gameData.diamonds);

                        placedList[pos].tag = "bigWaterPower";
                        dataManager.UpdateMap(pos, placedList[pos]);
                    }
                }

                if (temp.CompareTag("ResourceTower"))
                {
                    if ((dataManager.gameData.power - 55 >= 0) && (dataManager.gameData.water - 20 >= 0) && (dataManager.gameData.food - 20 >= 0) && (dataManager.gameData.resources - 350 >= 0) && (dataManager.gameData.diamonds - 10 >= 0))
                    {
                        dataManager.gameData.power -= 55;
                        dataManager.gameData.water -= 20;
                        dataManager.gameData.food -= 20;
                        dataManager.gameData.resources -= 350;
                        dataManager.gameData.diamonds -= 10;

                        resourcesTexts.PowerText(dataManager.gameData.power);
                        resourcesTexts.WaterText(dataManager.gameData.water);
                        resourcesTexts.FoodText(dataManager.gameData.food);
                        resourcesTexts.ResourcesText(dataManager.gameData.resources);
                        resourcesTexts.DiamondsText(dataManager.gameData.diamonds);

                        placedList[pos].tag = "bigResourceTower";
                        dataManager.UpdateMap(pos, placedList[pos]);
                    }
                }
            }
        }

    }

    public void setHospital()
    {
        choosen = hospitalPrefab;
    }

    public void setHouse()
    {
        choosen = smallHousePrefab;
    }

    public void setPlantation()
    {
        choosen = plantationPrefab;
    }

    public void setCentralTower()
    {
        choosen = centralTowerPrefab;
    }

    public void setWaterTower()
    {
        choosen = waterTowerPrefab;
    }

    public void setResourceTower()
    {
        choosen = resourceTowerPrefab;
    }

    public Dictionary<Vector2, GameObject> GetPlaced()
    {
        return placedList;
    }

    public void toggleButtons()
    {
        if (!isShowing)
        {
            btnHospital.gameObject.SetActive(true);
            btnHouses.gameObject.SetActive(true);
            isShowing = true;
            editMode = true;
        }
        else
        {
            btnHospital.gameObject.SetActive(false);
            btnHouses.gameObject.SetActive(false);
            isShowing = false;
            editMode = false;
        }
    }
}