using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastManager : MonoBehaviour
{
    private HeroManager heroManager;
    private GameManager gameManager;

    public GameObject boltSpell;
    private float spellSpeed = 10;
    private bool isManaShieldToggled = false;

    private void Start() {
        gameManager = GameManager.instance;
        heroManager = gameManager.heroManager;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && heroManager.GetHeroMovementManager().CanDash() )
        {
            StartCoroutine( heroManager.GetHeroMovementManager().Dash( ) );
        }
        CastbasicSpell();
        
        if( Input.GetKeyDown( KeyCode.E ) && heroManager.GetHeroManaManager().IsEnoughMana(30) )
        {
            heroManager.GetHeroManaManager().UseMana( 30 );
            CastAOESpell();
        }

        if( Input.GetKeyDown( KeyCode.F ) && heroManager.GetHeroManaManager().IsManaShieldLearned() )
        {
            isManaShieldToggled = !isManaShieldToggled; 
            heroManager.GetHeroManaManager().ToggleManaShield( isManaShieldToggled );
        }


    }

    private void CastbasicSpell()
    {
        if (Input.GetMouseButtonDown(0) && heroManager.GetHeroManaManager().IsEnoughMana( heroManager.GetHeroBasicSpellManager().GetManaCost() ) )
        {
            heroManager.GetHeroManaManager().UseMana( heroManager.GetHeroBasicSpellManager().GetManaCost() );
       
            Vector2 mousePositionMain = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPositionMain = transform.position;
            Vector2 directionMain = (mousePositionMain - myPositionMain).normalized;
            CreateBolt( 0, directionMain );

            int amountLevel = heroManager.GetHeroBasicSpellManager().GetAmountLevel();
            if ( amountLevel> 1)
            {
                CreateBolt( 10, directionMain );
            }

            if (amountLevel > 2)
            {
                CreateBolt( -10, directionMain );
            }

            if (amountLevel > 3)
            {
                CreateBolt( 20, directionMain );
            }
            if (amountLevel > 4)
            {   
                CreateBolt( -20, directionMain );
            }
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
        GameObject createdBoltSpell2 = Instantiate(original: boltSpell, transform.position, Quaternion.identity);
        Vector2 direction2 = Quaternion.Euler(0, 0, offset) * directionMain; // Add a 10-degree offset to the original direction
        createdBoltSpell2.GetComponent<Rigidbody2D>().velocity = direction2 * spellSpeed; // Use a slightly higher speed for the second spell
        int size = heroManager.GetHeroBasicSpellManager().GetSpellSize();
        createdBoltSpell2.transform.localScale = new Vector3( size, size, size );
    }
}
