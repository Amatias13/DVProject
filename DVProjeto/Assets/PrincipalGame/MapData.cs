using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData 
{
    public Vector2 vector2;
    public GameObject gameObject;

    public MapData(Vector2 vector2, GameObject gameObject)
    {
        this.vector2 = vector2;
        this.gameObject = gameObject;
    }
}
