using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    private HeroController heroController;
    private GameManager gameManager;
    public int spellLevel = 1;

    public GameObject boltSpell;
    public float spellSpeed;

    private void Start() {    
        gameManager = FindObjectOfType<GameManager>();
        heroController = gameManager.heroController;
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

            if (heroController.basicAttackAmountLevel > 1)
            {
                CreateBolt( 10, directionMain );
            }

            if (heroController.basicAttackAmountLevel > 2)
            {
                CreateBolt( -10, directionMain );
            }

            if (heroController.basicAttackAmountLevel > 3)
            {
                CreateBolt( 20, directionMain );
            }
            if (heroController.basicAttackAmountLevel > 4)
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
                createdBoltSpell2.transform.localScale = new Vector3( heroController.basicAttackSizeLevel, heroController.basicAttackSizeLevel, heroController.basicAttackSizeLevel );
    }

    private void CastDash()
    {
        if (Input.GetMouseButtonDown(1))
        {
            heroController.currentmovementSpeed = heroController.maxSpeed;
            StartCoroutine(dashDuration());

            StartCoroutine( SpellUpgradeDuration( spellLevel ) );
            heroController.basicAttackAmountLevel = heroController.basicAttackAmountLevelMax;
        }
    }

    IEnumerator dashDuration()
    {
        yield return new WaitForSeconds(0.18f);
        heroController.currentmovementSpeed = heroController.basicMovementSpeed;
    }

    IEnumerator SpellUpgradeDuration( int originalLevel )
    {
        yield return new WaitForSeconds( 4 );
        heroController.basicAttackAmountLevel = heroController.basicAttackAmountLevelLeveled;
    }
}
