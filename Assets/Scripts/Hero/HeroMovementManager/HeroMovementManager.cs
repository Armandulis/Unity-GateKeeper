using UnityEngine;

public class HeroMovementManager
{
    private int currentMovementSpeed = 5;
    private int basicMovementSpeed = 5;
    private int dashSpeed = 20;
    private Vector2 position;

    public void Move()
    {
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");
    }

    public Vector2 GetCurrentPosition()
    {
        return position;
    }

    public int GetCurrentMovementSpeed()
    {
        return currentMovementSpeed;
    }

    public void updateHeroPosition( Rigidbody2D heroRigidBody )
    {
        heroRigidBody.MovePosition( 
            heroRigidBody.position +
            position.normalized *
            currentMovementSpeed *
            Time.fixedDeltaTime
        ); 
    }
}