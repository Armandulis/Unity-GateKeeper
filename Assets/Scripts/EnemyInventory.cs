using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        Instantiate( inventory, transform.position, Quaternion.identity );
        Debug.Log("hello");
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.CompareTag( "Player" ) )
        {
            Debug.Log("HELLO");
        }    
    }
}
