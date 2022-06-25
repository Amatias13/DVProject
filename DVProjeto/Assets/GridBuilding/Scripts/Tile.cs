using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //Variaveis
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    private Vector2 tilePosition;
    [SerializeField] private GameObject sphere;
    private GridManager gridManager;

    //Construtor
    public void Init(bool isOffset, Vector2 pos, GridManager gridManager)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
        tilePosition = pos;
        this.gridManager = gridManager;
    }

    //Quando o rato passa por cima, muda a cor da tile
    void OnMouseEnter()
    {
        highlight.SetActive(true);        
    }

    //Quando o rato sai de cima, muda a cor da tile
    void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    //Ao clicar com o rato, devolve a posição
    private void OnMouseDown()
    {
        gridManager.onMapClick(tilePosition);
    }

}
