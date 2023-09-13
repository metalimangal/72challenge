using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private Projectile projectile;
    void Start()
    {
        projectile = this.gameObject.transform.parent.gameObject.GetComponent<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy1") || other.CompareTag("Enemy2")|| other.CompareTag("EnemyShot") || other.CompareTag("Asteroid"))
        {
            projectile.PlayerHit();
            Destroy(other.gameObject);
        }
    }
}
