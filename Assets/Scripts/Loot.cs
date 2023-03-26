using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    bool stayOnLoot = false;
    public GameObject scroll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown( KeyCode.F ) && stayOnLoot)
           {
              Instantiate( scroll, transform.position, Quaternion.identity );
              Destroy( gameObject );
           }
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.CompareTag( "Player" ) )
        {
            stayOnLoot = true;
            if( transform.Find( "FTooltip" ) )
            {
                Transform lootTooltipTransform = transform.Find( "FTooltip" ).transform;
                lootTooltipTransform.localScale = new Vector3( 1, 1, 1 );
            }
        }    
    }


    private void OnTriggerExit2D(Collider2D other) {
        if( other.CompareTag( "Player" ) )
        {
             stayOnLoot = false;
            if( transform.Find( "FTooltip" ) )
            {
                Transform lootTooltipTransform = transform.Find( "FTooltip" ).transform;
                lootTooltipTransform.localScale = new Vector3( 0, 0, 0 );
            }
        }
    }
}
