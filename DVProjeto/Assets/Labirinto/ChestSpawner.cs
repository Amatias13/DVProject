using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chest;

    void Start()
    {
        SpawnChest();
    }


    void SpawnChest()
    {
        for (int i = 0; i < 8; i++)
        {
            
            double probOfSpawn = Random.Range(0, 100);
            if (probOfSpawn / 100 <= 0.5)
            {
                Instantiate(chest, transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);
            }
        }
    }
}
