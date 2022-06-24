using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene()
    {
        int randomNumber = Random.Range(3, 5);
        SceneManager.LoadScene(randomNumber);
    }
}
