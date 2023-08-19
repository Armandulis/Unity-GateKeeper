using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCastManager : MonoBehaviour
{
    private HeroManager heroManager;
    private GameManager gameManager;

    public GameObject boltSpell;
    private float spellSpeed = 10;
    private bool isManaShieldToggled = false;
    
    public GameObject manaRefreshSkillButtonCD;
    public GameObject manaRefreshSkillButton;
    public GameObject manaRefreshSkillKeybind;

    private void Start() {
        gameManager = GameManager.instance;
        heroManager = gameManager.heroManager;
    }

    void Update()
    {
        // Basic 
        HandleBasicSpell();
        HandleBasicAOE();

        // Utility
        HandleDash();

        // Mana talents
        HandleManaShield();
        HandleRefreshMana();

        // Arcane talents
    }

    public void HandleRefreshMana()
    {
        if( !heroManager.GetHeroManaManager().IsRefreshManaTalentLearned() )
        { 
            return;
        }

        // If we did learn it, but we can't use it, it means it's on cd    
        if( !heroManager.GetHeroManaManager().canUseRefreshManaTalent )
        {
            manaRefreshSkillButtonCD.GetComponent<Image>().fillAmount -= 1 / heroManager.GetHeroManaManager().GetManaRefreshCooldown() * Time.deltaTime;
            return;
        };

        manaRefreshSkillButton.SetActive(true);
        manaRefreshSkillButtonCD.SetActive(true);
        manaRefreshSkillKeybind.SetActive(true);
        manaRefreshSkillButtonCD.GetComponent<Image>().fillAmount = 0;

        if( Input.GetKeyDown( KeyCode.R )  )
        {
            StartCoroutine( heroManager.GetHeroManaManager().UseRefreshManaTalent() );
            manaRefreshSkillButtonCD.GetComponent<Image>().fillAmount = 1;
        }

    }
    public void HandleManaShield()
    {
        if( !heroManager.GetHeroManaManager().IsManaShieldLearned() )
        {
            return;
        }

        if( Input.GetKeyDown( KeyCode.F ) )
        {
            isManaShieldToggled = !isManaShieldToggled; 
            heroManager.GetHeroManaManager().ToggleManaShield( isManaShieldToggled );
        }
    }

    public void HandleDash()
    {
        if( !heroManager.GetHeroMovementManager().CanDash())
        {
            return;
        }

        if (Input.GetMouseButtonDown(1) )
        {
            StartCoroutine( heroManager.GetHeroMovementManager().Dash( ) );
        }
    }
    public void HandleBasicAOE()
    {
        if( !heroManager.GetHeroManaManager().IsEnoughMana(30) )
        {
            return;
        }
        if( Input.GetKeyDown( KeyCode.E ) )
        {
            heroManager.GetHeroManaManager().UseMana( 30 );
            StartCoroutine( CastAOEPart() );
        }
    }

    private void HandleBasicSpell()
    {
        if( !heroManager.GetHeroManaManager().IsEnoughMana( heroManager.GetHeroBasicSpellManager().GetManaCost() ) )
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
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
