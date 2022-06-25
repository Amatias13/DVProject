using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour
{
    [SerializeField] private float time = 11f;

    /**
     * Espera at� que a coroutine termine a execu��o
     */
    
    void Start()
    {
        StartCoroutine(Wait());
    }

    /**
     * Espera um determinado tempo
     * e carrega cena responsaevl pela introdu��o do jogo.
     */
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(1);
    }
}
