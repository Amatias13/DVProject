using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData
{
    //Variaveis
    public Vector2 vector2;
    public GameObject gameObject;

    //Constutor do mapa com o item e a localização na grid
    public MapData(Vector2 vector2, GameObject gameObject)
    {
        this.vector2 = vector2;
        this.gameObject = gameObject;
    }
}
