using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCasterEnemy : MonoBehaviour
{
    
    public Slider healthSlider;
    public GameObject healthBar;

    private bool shouldChase = true;

    private GameObject player;
    
    public Rigidbody2D myRigidBody;
    public float speed;

    public bool startedShooting = false;

    public GameObject boltSpell;


    
    public float maxHealth = 100;
    public float currentHelth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {


        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= 5) {
            shouldChase = false;
             myRigidBody.velocity = Vector2.zero;
            
            if( !startedShooting )
            {
                startedShooting = true;
                StartCoroutine( CastSpell() );
            }
        }
        else{

            shouldChase = true;
            startedShooting = false;
        Vector2 playerPos = player.transform.position;
        Vector2 myPosition = transform.position;
        Vector2 direction = (playerPos - myPosition).normalized;
        myRigidBody.velocity = direction * speed;
        }

    }

    private IEnumerator CastSpell()
    {
        while(!shouldChase )
        {
            CreateBolt( player.transform.position );
            yield return new WaitForSeconds( 1 );
        }
        
            yield return new WaitForSeconds( 1 );
    }

        private void CreateBolt( Vector2 directionMain )
    {
                // Create the second spell
                GameObject createdBoltSpell2 = Instantiate(boltSpell, transform.position, Quaternion.identity);
                Vector2 direction2 = transform.position; // Add a 10-degree offset to the original direction
            
                 Vector2 direction = (directionMain - direction2).normalized;
                createdBoltSpell2.GetComponent<Rigidbody2D>().velocity = direction * 10; // Use a slightly higher speed for the second spell
                
                // createdBoltSpell2.transform.localScale = new Vector3( 1, 1, 1 );
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
            // Instantiate(inventory, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
