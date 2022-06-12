using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    private Vector2 tilePosition;

    public void Init(bool isOffset, Vector2 pos)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
        tilePosition = pos;
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
        Debug.Log(tilePosition.ToString());
    }
}
