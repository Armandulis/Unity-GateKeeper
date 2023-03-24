using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    bool hasUpgrade = false;
    public int bounceChangePercentage = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if( other.CompareTag( "Enemy" ) )
        {
            other.GetComponent<EnemyHealth>().TakeDamage( 10 );
            int RandomValue = Random.Range(1, 101);
            Debug.Log(RandomValue);
            
            Debug.Log(bounceChangePercentage);
            Debug.Log(RandomValue < bounceChangePercentage);
            if( RandomValue < bounceChangePercentage )
            {
                Vector2 randomDirection = Random.insideUnitCircle.normalized; // Generate a random direction vector
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity = randomDirection * 10;
                return;
            }
            
            Destroy( gameObject );
            
        }
    }
}
