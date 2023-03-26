using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyController enemyController;

    public GameObject inventory;

    public GameObject player;

    public Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyController.SelfSetupObject(gameObject);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 myPosition = transform.position;
        Vector2 direction = (playerPos - myPosition).normalized;
        myRigidBody.velocity = direction * enemyController.speed;
    }

    public void TakeDamage(float damage)
    {
        enemyController.currentHelth -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (enemyController.currentHelth <= 0)
        {
            Instantiate(inventory, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }



}
