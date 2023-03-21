using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public GameObject boltSpell;
    public float spellSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( CastBoltSpell() );
    }

    IEnumerator CastBoltSpell()
    {
        while( true )
        {
            yield return new WaitForSeconds( 1 );


            float x = Input.GetAxisRaw( "Horizontal" );
            float y = Input.GetAxisRaw( "Vertical");

            
            if( x == 0 && y == 0 )
            {
                x = 1;
            }

            GameObject createdBoltSpell = Instantiate( boltSpell, transform );
            Vector2 direction = new Vector2(  x, y);
            createdBoltSpell.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
        }
    }
}
