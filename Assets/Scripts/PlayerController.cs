using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;
    public float speed = 10f;
    float y = 0f;
    float gravity = -15f;

    public Transform fpsCamera;
    float pitch = 0f;

    [Range(5, 15)]
    float mouseSensitivity = 10f;

    [Range(45, 85)]
    float pitchRange = 45f;

    float x = 0f;
    float z = 0f;
    float xMouse = 0f;
    float yMouse = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        Vector3 move = new Vector3(x, 0, z);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        if (cc.isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {
                y = 15f;
            }
            else
            {
                y = gravity * Time.deltaTime;
            }
        }
        else
        {
            y += gravity * Time.deltaTime;
        }

        cc.Move((move + new Vector3(0, y, 0)) * Time.deltaTime);
        transform.Rotate(0,xMouse,0);
        pitch -= yMouse;
        pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);
        Quaternion camRotation = Quaternion.Euler(pitch, 0, 0);
        fpsCamera.localRotation = camRotation;
    }

    void GetInput()
    {
        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;
        xMouse = Input.GetAxis("Mouse X") * mouseSensitivity;
        yMouse = Input.GetAxis("Mouse Y") * mouseSensitivity;
    }

}
