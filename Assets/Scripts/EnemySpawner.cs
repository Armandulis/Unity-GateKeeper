using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( SpawnEnemy() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds( 10 );
            GameObject summonedEnemy = Instantiate( enemy, transform.position, Quaternion.identity );
            summonedEnemy.GetComponent<Enemy>().enemyController = enemyController;
        }
    }
}
