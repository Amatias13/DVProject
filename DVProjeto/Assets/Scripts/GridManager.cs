using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    
    [SerializeField] private Transform camera;
    private Dictionary<Vector2, Tile> tiles;

    [SerializeField] private GameObject circlePrefab;
    private GameObject createdCircle;
    [SerializeField] private GameObject squarePrefab;
    private GameObject createdSquare;

    private GameObject choosen;

    private void Start()
    {
        GenerateGrid();
        choosen = GameObject.FindWithTag("Teste");
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
        Instantiate(choosen, pos, Quaternion.identity);
        choosen.SetActive(true);
    }

    public void setCircle()
    {
        choosen = GameObject.FindWithTag("Teste");
        Debug.Log("oi");
    }

    public void setSquare()
    {
        choosen = GameObject.FindWithTag("Square");
        Debug.Log("Square");
    }
}
