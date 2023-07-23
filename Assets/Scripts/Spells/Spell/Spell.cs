using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private HeroManager heroManager;
    private int bounceChangePercentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        heroManager = GameManager.instance.heroManager;
        bounceChangePercentage = heroManager.GetHeroBasicSpellManager().CalculateBasicAttackBouncePercentage();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if( enemy )
            {
                enemy.TakeDamage(10);
            }
            else
            {
                SpellCasterEnemy spellCasterEnemy = other.GetComponent<SpellCasterEnemy>();
                spellCasterEnemy.TakeDamage(10);
            }

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
