using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject prefabToFire;
    public GameObject firePoint;
    public float shootTime = 5.0f;
    private GameController gameController;


    public enum SpaceshipType
    {
        Player,
        Enemy1,
        Enemy2
    }

    public SpaceshipType spaceshipType;
    float shootTimeNow;
    GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        shootTimeNow = 0;
        playerObject = GameObject.FindWithTag("Player");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && spaceshipType == SpaceshipType.Player)
        {
            Instantiate(prefabToFire, firePoint.transform.position, firePoint.transform.rotation);
        }
        else if(spaceshipType != SpaceshipType.Player)
        {
            if (playerObject != null)
            {
                Vector3 playerPosition = playerObject.transform.position;
                Vector3 enemyPosition = transform.position;

                RaycastHit hit;

                Debug.DrawRay(firePoint.transform.position, firePoint.transform.forward * 20, Color.red);

                if (Physics.Raycast(firePoint.transform.position, transform.forward * 20, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Player") && (!hit.collider.gameObject.CompareTag("Asteroid") && !hit.collider.gameObject.CompareTag("Enemy1") && !hit.collider.gameObject.CompareTag("Enemy2")))
                    {
                        Debug.Log("Hitting Player");
                        if (shootTimeNow >= shootTime)
                        {
                            Instantiate(prefabToFire, firePoint.transform.position, firePoint.transform.rotation);
                            shootTimeNow = 0;
                        }

                    }
                }

                shootTimeNow += Time.deltaTime;

            }

        }
    }

    public void PlayerHit()
    {


        if(spaceshipType == SpaceshipType.Player)
        {
            gameController.ReduceHealth();
            if (gameController.health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
