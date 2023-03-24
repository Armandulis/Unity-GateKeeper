using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    private bool hasMaxLevelBuff = false;
    public int spellLevel = 1;

    public float spellSize = 1;
    public GameObject boltSpell;
    public float spellSpeed;

    void Update()
    {
        CastbasicSpell();
        CastDash();
    }




    private void CastbasicSpell()
    {

        int localLevel = spellLevel;
        if( hasMaxLevelBuff )
        {
            localLevel = 6;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePositionMain = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPositionMain = transform.position;
            Vector2 directionMain = (mousePositionMain - myPositionMain).normalized;
            CreateBolt( 0, directionMain );

            if (localLevel > 1)
            {
                CreateBolt( 10, directionMain );

            }

            if (localLevel > 2)
            {
                CreateBolt( -10, directionMain );
            }

            if (localLevel > 3)
            {
                CreateBolt( 20, directionMain );
            }
            if (localLevel > 4)
            {   
                CreateBolt( -20, directionMain );
            }
        }
    }

    private void CreateBolt( int offset, Vector2 directionMain )
    {
                // Create the second spell
                GameObject createdBoltSpell2 = Instantiate(boltSpell, transform.position, Quaternion.identity);
                Vector2 direction2 = Quaternion.Euler(0, 0, offset) * directionMain; // Add a 10-degree offset to the original direction
                createdBoltSpell2.GetComponent<Rigidbody2D>().velocity = direction2 * spellSpeed; // Use a slightly higher speed for the second spell
                createdBoltSpell2.transform.localScale = new Vector3( spellSize, spellSize, spellSize );
    }

    private void CastDash()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.GetComponent<Player>().playerMovementSpeed = 20;
            StartCoroutine(dashDuration());

            StartCoroutine( SpellUpgradeDuration( spellLevel ) );
            hasMaxLevelBuff = true;
        }
    }

    IEnumerator dashDuration()
    {
        yield return new WaitForSeconds(0.18f);
        gameObject.GetComponent<Player>().playerMovementSpeed = 5;
    }

    IEnumerator SpellUpgradeDuration( int originalLevel )
    {
        yield return new WaitForSeconds(6);
        hasMaxLevelBuff = false;
    }
}
