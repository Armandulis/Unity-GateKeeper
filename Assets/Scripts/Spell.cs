using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private HeroStats heroStats;
    private int bounceChangePercentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        heroStats = gameManager.heroStats;
        bounceChangePercentage = heroStats.CalculateBasicAttackBouncePercentage();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(10);
            int RandomValue = Random.Range(1, 101);
            if (RandomValue < bounceChangePercentage)
            {
                bounceChangePercentage -= 25;
                Vector2 randomDirection = Random.insideUnitCircle.normalized; // Generate a random direction vector
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity = randomDirection * 10;
                return;
            }

            Destroy(gameObject);
        }
    }


}
