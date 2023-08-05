using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    HeroManager heroManager;
    public Slider healthSlider;
    public GameObject healthBar;

    // public 
    public GameObject inventory;

    private GameObject player;

    public Rigidbody2D myRigidBody;


    public float maxHealth = 100;
    public float currentHelth = 100;
    public float speed;

    public Vector2 colliderSize;
    public Vector2 colliderOffset;

    private bool coughtPlayer = false;

    public int experienceWorth = 50;

    // Start is called before the first frame update
    void Start()
    {
        
        heroManager = GameManager.instance.heroManager;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if( !coughtPlayer )
        {
            Vector2 playerPos = player.transform.position;
            Vector2 myPosition = transform.position;
            Vector2 direction = (playerPos - myPosition).normalized;
            myRigidBody.velocity = direction * speed;
        }
    }

    public void TakeDamage(float damage)
    {
        healthBar.SetActive( true );
        currentHelth -= damage;
        healthSlider.value = (currentHelth / maxHealth);
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (currentHelth <= 0)
        {
        
            heroManager.GetHeroLevelSystemManager().AddExperience( experienceWorth );
            heroManager.GetHeroManaManager().AddManaOnKill();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.CompareTag( "Player" ) ) 
        {
            
            coughtPlayer = true;
            StartCoroutine( DealDamage( other ) );
            myRigidBody.velocity = Vector2.zero; 
           
        }    
    }

    private IEnumerator DealDamage( Collider2D other )
    {
        
        while( coughtPlayer )
        {
            
            other.GetComponent<Player>().PlayerTakeDamage( 10 );
            
            yield return new WaitForSeconds( 1 );
        }
            yield return new WaitForSeconds( 1 );
    }

    private void OnTriggerExit2D(Collider2D other) {
        if( other.CompareTag( "Player" ) ) 
        {
            
        // coughtPlayer = false;
            StartCoroutine( StartChasingAgain() );
        }   
    }

    private IEnumerator StartChasingAgain()
    {
        yield return new WaitForSeconds(1);
        coughtPlayer = false;
    }



}
