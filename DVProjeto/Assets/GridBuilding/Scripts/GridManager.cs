using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    //Variaveis
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private GameObject smallHousePrefab;
    [SerializeField] private GameObject bigHousePrefab;
    [SerializeField] private GameObject plantationPrefab;
    [SerializeField] private GameObject powerTowerPrefab;
    [SerializeField] private GameObject waterTowerPrefab;
    [SerializeField] private GameObject resourceTowerPrefab;
    [SerializeField] private GameObject popUpMessage;
    [SerializeField] private Transform camera;
    [SerializeField] private int width, height;
    [SerializeField] private float money;
    [SerializeField] private Button btnHouse, btnPlantation, btnPowerTower, btnWaterTower, btnResourceTower;
    private Boolean isShowing;
    private Boolean editMode;

    private GameObject choosen;
    private DataManager dataManager;
    private ResourcesTexts resourcesTexts;

    private Dictionary<Vector2, GameObject> placedList;
    private Dictionary<Vector2, Tile> tiles;

    //Ao iniciar, gera o tabuleiro de jogo
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

    //Este metodo gera o tabuleiro, de tamanho recebido por parametro, e mete as tiles em cada uma das posições. Guarda também numa lista para depois dar load
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

    //OnClick no mapa, recebe a posição da tile onde foi clicada e corre a ação associada
    public void onMapClick(Vector2 pos)
    {
        //Se estiver no modo editar
        if (editMode)
        {
            //Se a tile estiver vazia
            if (!placedList.ContainsKey(pos))
            {
                //Se o utilizador quiser por uma casa pequena, verifica se tem recursos. Se tiver, mete e atualiza os valores
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
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to create a new construction");

                //Se o utilizador quiser por uma plantação, verifica se tem recursos. Se tiver, mete e atualiza os valores
                else if (choosen.CompareTag("Plantation"))
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
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to create a new construction");

                //Se o utilizador quiser por uma torre de energia, verifica se tem recursos. Se tiver, mete e atualiza os valores
                else if (choosen.CompareTag("PowerTower"))
                    if ((dataManager.gameData.resources - 70 >= 0))
                    {
                        GameObject obj = Instantiate(choosen, pos, Quaternion.identity);
                        placedList[pos] = obj;

                        dataManager.gameData.resources -= 70;

                        resourcesTexts.ResourcesText(dataManager.gameData.resources);

                        dataManager.AddToMap(pos, choosen);
                    }
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to create a new construction");

                //Se o utilizador quiser por uma torre de agua, verifica se tem recursos. Se tiver, mete e atualiza os valores
                else if (choosen.CompareTag("WaterTower"))
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
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to create a new construction");


                //Se o utilizador quiser por uma torre de recursos, verifica se tem recursos. Se tiver, mete e atualiza os valores
                else if (choosen.CompareTag("ResourceTower"))
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
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to create a new construction");

            }
            else
            {
                //UPGRADES

                GameObject temp = placedList[pos];

                //Se o utilizador quiser dar upgrade à casa, verifica se tem recursos e se tiver, faz a alteração
                if (temp.CompareTag("SmallHouse") && choosen.CompareTag(temp.tag))
                {
                    if ((dataManager.gameData.power - 20 >= 0) && (dataManager.gameData.water - 20 >= 0) && (dataManager.gameData.resources - 200 >= 0) && (dataManager.gameData.diamonds - 10 >= 0))
                    {
                        Destroy(temp);
                        GameObject super = bigHousePrefab;
                        GameObject obj = Instantiate(super, pos, Quaternion.identity);
                        placedList[pos] = obj;

                        dataManager.gameData.power -= 20;
                        dataManager.gameData.water -= 20;
                        dataManager.gameData.resources -= 200;
                        dataManager.gameData.diamonds -= 10;

                        resourcesTexts.PowerText(dataManager.gameData.power);
                        resourcesTexts.WaterText(dataManager.gameData.water);
                        resourcesTexts.ResourcesText(dataManager.gameData.resources);
                        resourcesTexts.DiamondsText(dataManager.gameData.diamonds);

                        dataManager.UpdateMap(pos, super);
                    }
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to upgrade that construction");
                }

                //Se o utilizador quiser dar upgrade à plantação, verifica se tem recursos e se tiver, faz a alteração
                if (temp.CompareTag("Plantation") && choosen.CompareTag(temp.tag))
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
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to upgrade that construction");

                }

                //Se o utilizador quiser dar upgrade à torre de energia, verifica se tem recursos e se tiver, faz a alteração
                if (temp.CompareTag("PowerTower") && choosen.CompareTag(temp.tag))
                {
                    if ((dataManager.gameData.resources - 130 >= 0) && (dataManager.gameData.diamonds - 10 >= 0))
                    {
                        dataManager.gameData.resources -= 130;
                        dataManager.gameData.diamonds -= 10;

                        resourcesTexts.ResourcesText(dataManager.gameData.resources);
                        resourcesTexts.DiamondsText(dataManager.gameData.diamonds);

                        placedList[pos].tag = "bigPowerTower";
                        dataManager.UpdateMap(pos, placedList[pos]);
                    }
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to upgrade that construction");
                }

                //Se o utilizador quiser dar upgrade à torre de água, verifica se tem recursos e se tiver, faz a alteração
                if (temp.CompareTag("WaterTower") && choosen.CompareTag(temp.tag))
                {
                    if ((dataManager.gameData.power - 20 >= 0) && (dataManager.gameData.resources - 150 >= 0) && (dataManager.gameData.diamonds - 10 >= 0))
                    {
                        dataManager.gameData.power -= 20;
                        dataManager.gameData.resources -= 150;
                        dataManager.gameData.diamonds -= 10;

                        resourcesTexts.PowerText(dataManager.gameData.power);
                        resourcesTexts.ResourcesText(dataManager.gameData.resources);
                        resourcesTexts.DiamondsText(dataManager.gameData.diamonds);

                        placedList[pos].tag = "bigWaterTower";
                        dataManager.UpdateMap(pos, placedList[pos]);
                    }
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to upgrade that construction");
                }

                //Se o utilizador quiser dar upgrade à torre de recursos, verifica se tem recursos e se tiver, faz a alteração
                if (temp.CompareTag("ResourceTower") && choosen.CompareTag(temp.tag))
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
                    else
                        popUpMessage.transform.GetChild(0).GetComponent<PopUpScript>().setText("You don't have resources to upgrade that construction");
                }
            }
        }

    }

    //Define o tipo de item a colocar
    public void setHouse()
    {
        choosen = smallHousePrefab;
    }

    //Define o tipo de item a colocar
    public void setPlantation()
    {
        choosen = plantationPrefab;
    }

    //Define o tipo de item a colocar
    public void setPowerTower()
    {
        choosen = powerTowerPrefab;
    }

    //Define o tipo de item a colocar
    public void setWaterTower()
    {
        choosen = waterTowerPrefab;
    }

    //Define o tipo de item a colocar
    public void setResourceTower()
    {
        choosen = resourceTowerPrefab;
    }

    //Devolve a lista
    public Dictionary<Vector2, GameObject> GetPlaced()
    {
        return placedList;
    }

    //Ativa ou desativa o modo de editar e os seus botões
    public void toggleButtons()
    {
        if (!isShowing)
        {
            btnPlantation.gameObject.SetActive(true);
            btnPowerTower.gameObject.SetActive(true);
            btnWaterTower.gameObject.SetActive(true);
            btnResourceTower.gameObject.SetActive(true);
            btnHouse.gameObject.SetActive(true);
            isShowing = true;
            editMode = true;
        }
        else
        {
            btnPlantation.gameObject.SetActive(false);
            btnPowerTower.gameObject.SetActive(false);
            btnWaterTower.gameObject.SetActive(false);
            btnResourceTower.gameObject.SetActive(false);
            btnHouse.gameObject.SetActive(false);
            isShowing = false;
            editMode = false;
        }
    }
}