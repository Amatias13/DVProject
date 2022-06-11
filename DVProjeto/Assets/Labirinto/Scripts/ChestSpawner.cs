using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chest;
    [SerializeField] private int numberOfChest;
    [SerializeField] private float numberOfSpawnsPercentage;

    void Start()
    {
        SpawnChest();
    }


    void SpawnChest()
    {
        for (int i = 0; i < numberOfChest; i++)
        {
            
            double probOfSpawn = Random.Range(0, 100);
            if (probOfSpawn / 100 <= numberOfSpawnsPercentage)
            {
                Instantiate(chest, transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);
            }
        }
    }
}
