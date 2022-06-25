using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //Variaveis
    [SerializeField] private Transform cameraPos;

    //Acompanha o jogador
    void Update()
    {
        transform.position = cameraPos.position;
    }
}
