using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_CTRL : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 10.0f;
    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 localMovement = new Vector3(horizontalInput * speed, 0.0f, verticalInput*speed);
        transform.Translate(transform.TransformDirection(localMovement) * Time.deltaTime);
       
    }
}
