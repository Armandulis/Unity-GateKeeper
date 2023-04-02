using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicSpell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().PlayerTakeDamage(10);
            Destroy(gameObject);
        }
    }


}
