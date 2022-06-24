using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public int diamonds;
    public int power;
    public int water;
    public int resources;
    public int food;
    public int people;
    public List<MapData> placedList;

    public GameData(int diamonds, int power, int water, int resources, int food, int people, List<MapData> placedList)
    {
        this.diamonds = diamonds;
        this.power = power;
        this.water = water;
        this.resources = resources;
        this.food = food;
        this.people = people;
        this.placedList = new List<MapData>();
    }
}
