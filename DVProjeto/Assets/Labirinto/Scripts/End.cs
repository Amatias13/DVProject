using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject endObject;

    private float time;
    private Movement movement;
    private Begin begin;
    private Menu menu;

    void Start()
    {
        time = 0;
        movement = FindObjectOfType<Movement>();
        begin = FindObjectOfType<Begin>();
        menu = FindObjectOfType<Menu>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            time = 2f;
            movement.Kill(); 
            begin.Pause();
            begin.EndGame();
            menu.StopMusic();
            endObject.SetActive(true);
        }
    }
}
