using UnityEngine;
using System.Collections.Generic;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject typeTrap1;
    [SerializeField] private GameObject typeTrap2;
    [SerializeField] private int  numberOfTraps;

    private List<GameObject> traps = new List<GameObject>();

    void Start()
    {
        traps.Add(typeTrap1);
        traps.Add(typeTrap2);   

        SpawnTrap();
    }


    void SpawnTrap()
    {

        for (int i = 0; i < numberOfTraps; i++)
        {
            int typeOfTrap = Random.Range(0, 2);

            Instantiate(traps[typeOfTrap], transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);

        }
    }
}
