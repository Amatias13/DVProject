using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour
{
    [SerializeField] private float time = 11f;

    /**
     * Espera até que a coroutine termine a execução
     */
    
    void Start()
    {
        StartCoroutine(Wait());
    }

    /**
     * Espera um determinado tempo
     * e carrega cena responsaevl pela introdução do jogo.
     */
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(1);
    }
}
