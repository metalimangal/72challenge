using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 3.0f; // Speed at which the asteroid moves along the z-axis

    void Update()
    {
        // Move the asteroid along the z-axis
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Destroy the asteroid when it goes out of bounds (you can adjust this threshold)
        if (transform.position.z < -2.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ProtonShot"))
        {
            Destroy(gameObject);
        }
    }
}

