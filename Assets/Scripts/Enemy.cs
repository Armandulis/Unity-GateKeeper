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
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 myPosition = transform.position;
        Vector2 direction = (playerPos - myPosition).normalized;
        myRigidBody.velocity = direction * speed;
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



}
