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
        heroManager.GetHeroMovementManager().Dash();
    }

    void FixedUpdate()
    {
        heroManager.GetHeroMovementManager().updateHeroPosition(myRigidBody);
    }

    public void PlayerTakeDamage(float damage)
    {
        heroManager.GetHeroHealthManager().TakeDamage( damage); 
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
