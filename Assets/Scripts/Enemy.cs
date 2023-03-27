using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject inventory;

    private GameObject player;

    public Rigidbody2D myRigidBody;

    
    public float maxHealth = 100;
    public float currentHelth = 100;
    public Sprite sprite;
    public float speed;

    public Vector2 colliderSize;
    public Vector2 colliderOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.GetComponent<CapsuleCollider2D>().size = colliderSize;
        gameObject.GetComponent<CapsuleCollider2D>().offset = colliderOffset;
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
        currentHelth -= damage;
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
