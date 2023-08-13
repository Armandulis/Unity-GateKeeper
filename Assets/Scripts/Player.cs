using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private HeroManager heroManager;
    private GameManager gameManager;

    public Slider healthSlider;
    public Slider manaSlider;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    public GameObject skillTree;

    private bool talentsOpened;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance; 
        heroManager = gameManager.heroManager;
    }

    // Update is called once per frame
    void Update()
    {
        manaSlider.value = heroManager.GetHeroManaManager().GetManaPercentage();
        heroManager.GetHeroMovementManager().Move();
        heroManager.GetHeroManaManager().ToggleNotMovingManaRegen(
            heroManager.GetHeroMovementManager().IsMoving()
        );

        if( Input.GetKeyDown( KeyCode.N ))
        {
            skillTree.SetActive( !talentsOpened );
            talentsOpened = !talentsOpened;
        }
    }
    void FixedUpdate()
    {
        heroManager.GetHeroMovementManager().updateHeroPosition(myRigidBody);
    }

    public void PlayerTakeDamage(float damage)
    {
        float damageRemainder = heroManager.GetHeroManaManager().CheckManaForHealthModifiers(damage);
        if( damageRemainder > 0) 
        {
            heroManager.GetHeroHealthManager().TakeDamage(damage); 
        }
        heroManager.GetHeroManaManager().AddManaOnGettingDamaged();
        healthSlider.value = heroManager.GetHeroHealthManager().GetHealthPercentage();
    }


    public void CheckDeath()
    {
        if(heroManager.GetHeroHealthManager().IsDead() )
        {
            // DO SOMETHING
        }
    }
}
