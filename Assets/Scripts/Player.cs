using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private HeroStats heroStats;
    private GameManager gameManager;

    Vector2 movement;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        heroStats = gameManager.heroStats;
    }

    // Update is called once per frame
    void Update()
    {
        if( heroStats.currentmovementSpeed < heroStats.maxSpeed )
        {
           movement.x = Input.GetAxisRaw( "Horizontal" );
           movement.y = Input.GetAxisRaw( "Vertical" );
        }
    }

    void FixedUpdate() 
    {      
        heroStats = gameManager.heroStats;
        myRigidBody.MovePosition( myRigidBody.position + movement.normalized * heroStats.currentmovementSpeed * Time.fixedDeltaTime );
    }
}
