using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    private HeroStats heroStats;
    private GameManager gameManager;
    public int spellLevel = 1;

    public GameObject boltSpell;
    public float spellSpeed;

    private void Start() {
        gameManager = GameManager.instance;
        heroStats = gameManager.heroStats;
    }

    void Update()
    {
        CastbasicSpell();
        CastDash();
    }

    private void CastbasicSpell()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePositionMain = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPositionMain = transform.position;
            Vector2 directionMain = (mousePositionMain - myPositionMain).normalized;
            CreateBolt( 0, directionMain );

            if (heroStats.basicAttackAmountLevel > 1)
            {
                CreateBolt( 10, directionMain );
            }

            if (heroStats.basicAttackAmountLevel > 2)
            {
                CreateBolt( -10, directionMain );
            }

            if (heroStats.basicAttackAmountLevel > 3)
            {
                CreateBolt( 20, directionMain );
            }
            if (heroStats.basicAttackAmountLevel > 4)
            {   
                CreateBolt( -20, directionMain );
            }
        }

        if( Input.GetKeyDown( KeyCode.E ) )
        {
            CastAOESpell();
        }
    }
    private void CastAOESpell()
    {
        StartCoroutine( CastAOEPart() );
    }

    IEnumerator CastAOEPart()
    {
        Vector2 mousePositionMain = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPositionMain = transform.position;
        Vector2 directionMain = (mousePositionMain - myPositionMain).normalized;

        int castedCount = 0;
        int lastOffsetTop = 0;
        int lastOffsetBottom = 180;
        int amount = 50;

        while( castedCount < amount )
        {
            yield return new WaitForSeconds( 0.03f );

             CreateBolt( lastOffsetTop , directionMain );
             lastOffsetTop += 360 / amount;
             castedCount++;  


            CreateBolt( lastOffsetBottom , directionMain );
            lastOffsetBottom += ( 360 / amount);
            castedCount++; 
             
        }
    }

    private void CreateBolt( int offset, Vector2 directionMain )
    {
                // Create the second spell
                GameObject createdBoltSpell2 = Instantiate(boltSpell, transform.position, Quaternion.identity);
                Vector2 direction2 = Quaternion.Euler(0, 0, offset) * directionMain; // Add a 10-degree offset to the original direction
                createdBoltSpell2.GetComponent<Rigidbody2D>().velocity = direction2 * spellSpeed; // Use a slightly higher speed for the second spell
                createdBoltSpell2.transform.localScale = new Vector3( heroStats.basicAttackSizeLevel, heroStats.basicAttackSizeLevel, heroStats.basicAttackSizeLevel );
    }

    private void CastDash()
    {
        if (Input.GetMouseButtonDown(1))
        {
            heroStats.currentmovementSpeed = heroStats.maxSpeed;
            StartCoroutine(dashDuration());

            StartCoroutine( SpellUpgradeDuration( spellLevel ) );
            heroStats.basicAttackAmountLevel = heroStats.basicAttackAmountLevelMax;
        }
    }

    IEnumerator dashDuration()
    {
        yield return new WaitForSeconds(0.18f);
        heroStats.currentmovementSpeed = heroStats.basicMovementSpeed;
    }

    IEnumerator SpellUpgradeDuration( int originalLevel )
    {
        yield return new WaitForSeconds( 4 );
        heroStats.basicAttackAmountLevel = heroStats.basicAttackAmountLevelLeveled;
    }
}
