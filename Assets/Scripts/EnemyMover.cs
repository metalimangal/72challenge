using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 3.0f;
    private GameController gameController;
    public Vector3 translation;

    void Update()
    {
        transform.Translate(translation * speed * Time.deltaTime);

        // Destroy the asteroid when it goes out of bounds (you can adjust this threshold)
        if(this.CompareTag("Enemy1") || this.CompareTag("Enemy2"))
        {
            if(transform.position.x < -10.0f || transform.position.x > 10.0f)
            {
                translation = new Vector3(translation.x * -1, translation.y, translation.z);
            }
        }
        if (transform.position.z < -2.0f)
        {
            Destroy(gameObject);
        }
        if (this.CompareTag("UFO") && transform.position.x >= 12)
        {
            Destroy(gameObject);
        }
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ProtonShot"))
        {

            int score = 100;
            if (this.CompareTag("Enemy1"))
            {
                score = 200;
            }
            else if (this.CompareTag("Enemy2"))
            {
                score = 300;
            }
            else if (this.CompareTag("UFO"))
            {
                score = 1000;
            }
            gameController.AddScore(score);
            Destroy(gameObject);


        }
    }
}

