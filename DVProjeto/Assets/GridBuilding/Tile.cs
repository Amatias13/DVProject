using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    private Vector2 tilePosition;
    [SerializeField] private GameObject sphere;
    private GridManager gridManager;

    public void Init(bool isOffset, Vector2 pos, GridManager gridManager)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
        tilePosition = pos;
        this.gridManager = gridManager;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);        
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        gridManager.onMapClick(tilePosition);
    }

}
