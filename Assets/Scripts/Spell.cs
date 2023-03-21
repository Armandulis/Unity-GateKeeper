using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
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
            Destroy( gameObject );
        }
    }
}
