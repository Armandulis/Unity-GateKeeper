using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public GameObject boltSpell;
    public float spellSpeed;

    void Update() {
        CastbasicSpell();
        CastDash();
    }

    private void CastbasicSpell()
    {
                  if( Input.GetMouseButtonDown( 0 ) )
            {
                GameObject createdBoltSpell = Instantiate( boltSpell, transform );
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
                Vector2 myPosition = transform.position ;
                Vector2 direction = ( mousePosition - myPosition ).normalized;
                createdBoltSpell.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
             }
    }

    private void CastDash()
    {
                if(Input.GetMouseButtonDown(1) )
        {
        gameObject.GetComponent<Player>().playerMovementSpeed = 20;
        StartCoroutine( dashDuration() );
        }
    }

    IEnumerator dashDuration()
    {
        Debug.Log( "hello0" );
        yield return new WaitForSeconds(0.18f);
        Debug.Log( "hello1" );


         gameObject.GetComponent<Player>().playerMovementSpeed = 5;
        
    }
}
