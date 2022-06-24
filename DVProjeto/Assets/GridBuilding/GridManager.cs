using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{

    [SerializeField] private Tile tilePrefab;
    [SerializeField] private GameObject hospitalPrefab;
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private Transform camera;
    [SerializeField] private int width, height;
    //[SerializeField] private Text moneyText;
    [SerializeField] private float money;

    private GameObject choosen;
    private Dictionary<Vector2, GameObject> placedList;
    private Dictionary<Vector2, Tile> tiles;
    private int hospitalCost = 250;
    private int houseCost = 100;
    private DataManager dataManager;

    private void Start()
    {
        GenerateGrid();
        choosen = housePrefab; 
        placedList = new Dictionary<Vector2, GameObject>();
        dataManager = gameObject.GetComponent<DataManager>();
        //moneyText.text = money.ToString();
    }

    public void GenerateGrid()
    {

        tiles = new Dictionary<Vector2, Tile>();
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset, new Vector2(x,y), this);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        camera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        camera.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
    }

    public void onMapClic(Vector2 pos)
    {
        Debug.Log(pos);
        if (!placedList.ContainsKey(pos))
        {
            if (choosen.CompareTag("Hospital"))
                if ((money - hospitalCost) >= 0)
                {
                    Instantiate(choosen, pos, Quaternion.identity);
                    placedList[pos] = choosen;
                    dataManager.SetMap(placedList);
                    money -= hospitalCost;
                    //moneyText.text = money.ToString();
                }
                else Debug.Log("Não há dinheiro");

            if (choosen.CompareTag("House"))
                if ((money - houseCost) >= 0)
                {
                    Instantiate(choosen, pos, Quaternion.identity);
                    placedList[pos] = choosen;
                    dataManager.SetMap(placedList);
                    money -= houseCost;
                    //moneyText.text = money.ToString();
                }
                else Debug.Log("Não há dinheiro");
        }
        else Debug.Log("Espaço já ocupado");

    }

    public void setHospital()
    {
        choosen = hospitalPrefab;         
    }

    public void setHouse()
    {
        choosen = housePrefab;
    }

    public Dictionary<Vector2, GameObject> GetPlaced()
    {
        return placedList;
    }
}
