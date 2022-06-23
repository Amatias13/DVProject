using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    
    [SerializeField] private Transform camera;
    [SerializeField] private GameObject circlePrefab;
    private GameObject createdCircle;
    [SerializeField] private GameObject squarePrefab;
    private GameObject createdSquare;
    private int circleNumber, squareNumber;

    private GameObject choosen;

    private Dictionary<Vector2, GameObject> placedList;
    private Dictionary<Vector2, Tile> tiles;

    private void Start()
    {
        GenerateGrid();
        choosen = GameObject.FindWithTag("Teste");
        placedList = new Dictionary<Vector2, GameObject>();
        circleNumber = 5;
        squareNumber = 5;
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

    /*public Tile getTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile))
            return tile;
        return null;
    }*/


    public void setClicked(Vector2 pos)
    {
        if (!placedList.ContainsKey(pos))
        {
            if (choosen.CompareTag("Teste"))
                if (circleNumber > 0)
                {
                    Instantiate(choosen, pos, Quaternion.identity);
                    placedList[pos] = choosen;
                    circleNumber--;
                }
                else Debug.Log("não há mais");

            if (choosen.CompareTag("Square"))
                if (squareNumber > 0)
                {
                    Instantiate(choosen, pos, Quaternion.identity);
                    placedList[pos] = choosen;
                    squareNumber--;
                }
                else Debug.Log("não há mais");
        }
        else Debug.Log("Já ocupado");

    }

    public void setCircle()
    {
        choosen = GameObject.FindWithTag("Teste");            
    }

    public void setSquare()
    {
        choosen = GameObject.FindWithTag("Square");
    }
}
