using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    private float sense;
    private float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sense = PlayerPrefs.GetFloat("sensitivity") * 10;
        Debug.Log(sense);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sense;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sense;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    public float GetSense()
    {
        return sense;
    }
    public void SetSense(float sense)
    {
        this.sense = sense*10;
    }

    public void StopCamera()
    {
        sense = 0f;
    }
}
