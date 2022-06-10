using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSript : MonoBehaviour
{
    private Animator animator;
    private float time;

    // Update is called once per frame
    void Start()
    {
        animator = GetComponent<Animator>();
        time = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                animator.Play("Fantasy_Polygon_Chest_Animation");
                time = 2.5f;
                transform.GetChild(3).gameObject.SetActive(false);
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        transform.GetChild(3).gameObject.SetActive(false);
    }

    void Update()
    {
        if (time != 0)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
