using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public int playerMovementSpeed = 5;



    Vector2 movement;
    [SerializeField]
    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if( playerMovementSpeed == 5 )
        {
           movement.x = Input.GetAxisRaw( "Horizontal" );
           movement.y = Input.GetAxisRaw( "Vertical" );
        }
    }

    void FixedUpdate() 
    {      
        myRigidBody.MovePosition( myRigidBody.position + movement.normalized * playerMovementSpeed * Time.fixedDeltaTime );
    }
}
