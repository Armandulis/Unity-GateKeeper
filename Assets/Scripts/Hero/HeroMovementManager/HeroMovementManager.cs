using System.Collections;
using UnityEngine;

public class HeroMovementManager
{
    private int currentMovementSpeed = 5;
    private int baseMovementSpeed = 5;
    private int dashSpeed = 20;
    private float dashDuration = 0.18f;
    private float dashCooldown = 1f;
    private bool isDashing = false;
    private bool isMoving = false;
    private bool canDash = true;
    private Vector2 position;

    public void Move()
    {
        if( isDashing )
        {
            return;
        } 

        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");
        if(position.x == 0 && position.y == 0 )
        {
            isMoving = false;
        }
        else{
            isMoving = true;
        }
    }

    public bool IsMoving()
    {
        return isMoving || isDashing;
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

    public bool CanDash()
    {
        return canDash;
    }

    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        currentMovementSpeed = dashSpeed;
        yield return new WaitForSeconds( dashDuration );
        isDashing = false;
        currentMovementSpeed = baseMovementSpeed;


        yield return new WaitForSeconds( dashCooldown );
        canDash = true;
    }
}