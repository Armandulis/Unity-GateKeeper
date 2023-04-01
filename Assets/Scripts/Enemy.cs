using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
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
            Instantiate(inventory, transform.position, Quaternion.identity);
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
        yield return new WaitForSeconds(2);
        coughtPlayer = false;
    }



}
