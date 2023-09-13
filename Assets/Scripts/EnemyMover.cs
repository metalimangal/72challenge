using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 3.0f;
    private GameController gameController;
    public Vector3 translation;

    private int numHits = 0;

    void Update()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        float currentSpeed = speed + (gameController.GetScore()*speed / 10000);

        transform.Translate(translation * currentSpeed * Time.deltaTime);

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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ProtonShot"))
        {

            int score = 100;
            if (this.CompareTag("Asteroid"))
            {
                gameController.AddScore(score);
                Destroy(gameObject);
            }
            if (this.CompareTag("Enemy1"))
            {
                score = 200;
                gameController.AddScore(score);
                Destroy(gameObject);
            }
            else if (this.CompareTag("Enemy2"))
            {
                if (numHits >= 5)
                {
                    score = 300;
                    gameController.AddScore(score);
                    Destroy(gameObject);
                }
                else
                {
                    numHits++;
                }

            }
            else if (this.CompareTag("UFO"))
            {
                score = 1000;
                gameController.AddScore(score);
                Destroy(gameObject);
            }



        }
    }
}

