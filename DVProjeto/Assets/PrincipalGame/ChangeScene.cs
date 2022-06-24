using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene()
    {
        int randomNumber = Random.Range(2, 4);
        SceneManager.LoadScene(randomNumber);
    }
}
