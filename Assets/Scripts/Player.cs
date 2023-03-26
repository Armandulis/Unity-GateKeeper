using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private HeroController heroController;
    private GameManager gameManager;

    Vector2 movement;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        heroController = gameManager.heroController;
    }

    // Update is called once per frame
    void Update()
    {
        if( heroController.currentmovementSpeed < heroController.maxSpeed )
        {
           movement.x = Input.GetAxisRaw( "Horizontal" );
           movement.y = Input.GetAxisRaw( "Vertical" );
        }
    }

    void FixedUpdate() 
    {      
        heroController = gameManager.heroController;
        myRigidBody.MovePosition( myRigidBody.position + movement.normalized * heroController.currentmovementSpeed * Time.fixedDeltaTime );
    }
}
