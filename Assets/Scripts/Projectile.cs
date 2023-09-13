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
    // Start is called before the first frame update
    void Start()
    {
        shootTimeNow = shootTime;
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
            if (shootTimeNow > 0)
            {
                shootTimeNow -= Time.deltaTime; 
            }
            else
            {
                Instantiate(prefabToFire, firePoint.transform.position, firePoint.transform.rotation);
                shootTimeNow = shootTime;
            }
        }
    }

    public void PlayerHit()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

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
