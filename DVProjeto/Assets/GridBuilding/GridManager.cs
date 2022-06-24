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
    [SerializeField] private Transform camera;
    [SerializeField] private int width, height;
    [SerializeField] private float money;
    [SerializeField] private Button btnHouses, btnHospital;
    private Boolean isShowing;
    private Boolean editMode;

    private GameObject choosen;
    private DataManager dataManager;


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

    public void onMapClic(Vector2 pos)
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
                    if ((money - houseCost) >= 0)
                    {
                        GameObject obj = Instantiate(choosen, pos, Quaternion.identity);
                        placedList[pos] = obj;
                        money -= houseCost;
                        dataManager.AddToMap(pos, choosen);
                    }
                    else Debug.Log("Não há dinheiro");
            }
            else
            {
                GameObject temp = placedList[pos];
                if (temp.CompareTag("SmallHouse"))
                {
                    if ((money - 300) >= 0)
                    {
                        Destroy(temp);
                        GameObject super = bigHousePrefab;
                        GameObject obj = Instantiate(super, pos, Quaternion.identity);
                        placedList[pos] = obj;
                        money -= 300;
                        //moneyText.text = money.ToString();
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