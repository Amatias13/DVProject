using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    private float sense;
    private float xRotation = 0f;

    /*
     * coloca o estado do curso com bloqueado e invisivel
     * recebe a sensibilidade das PlayerPrefs e multiplica por 10
     */
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sense = PlayerPrefs.GetFloat("sensitivity") * 10;
    }

    // a cada frame move a camera do jogador
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sense;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sense;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    // retorna a sensibilidade
    public float GetSense()
    {
        return sense;
    }

    //altera a sensibilidade 
    public void SetSense(float sense)
    {
        this.sense = sense*10;
    }

    // coloca a sense a 0 para a camera ficar bloqueada
    public void StopCamera()
    {
        sense = 0f;
    }
}
