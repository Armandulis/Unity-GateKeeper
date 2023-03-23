using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public GameObject player;

    public Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;    


    }

    private void Update() {
        
        Vector2 playerPos = player.transform.position;
        Vector2 myPosition = transform.position ;
        Vector2 direction = ( playerPos - myPosition ).normalized;
        myRigidBody.velocity = direction * 5;
    }
    
    public void TakeDamage( float damage )
    {
    


        currentHealth -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if( currentHealth <= 0 )
        {
            Destroy(gameObject);
        }
    }



}
