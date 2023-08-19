using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int currentWave = 1;
    public int waveValue = 1;
    public List<GameObject> enemies;// = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<Transform> spawnLocations;
    public float waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    private float nextWaveTimer;
    public TMP_Text currentWaveText;
    public TMP_Text waveTimerRemainingText;

    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentWaveText.text = "Current wave:" + currentWave;
        waveTimerRemainingText.text = "Wave timer:" + nextWaveTimer;
        if( spawnTimer <= 0 )
        {

            if(enemiesToSpawn.Count > 0 )
            {
                int spawnIndex = Random.Range(0, spawnLocations.Count);
                Instantiate(
                    enemiesToSpawn[0],
                    spawnLocations[spawnIndex].position,
                    Quaternion.identity
                    );
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval; // set cooldown for spawning so spawn every 2 seconds or so 
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime; // Time between spawning new enemy in the wave
        }
        
        waveTimer -= Time.fixedDeltaTime;
        nextWaveTimer -= Time.fixedDeltaTime;

        if(nextWaveTimer <= 0 )
        {
            spawnTimer = 0;
            currentWave++;
            GenerateWave();
        }
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        waveDuration = currentWave + 20;
        nextWaveTimer = waveDuration + 10;

        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        Debug.Log(spawnInterval);
        Debug.Log(waveDuration);
        Debug.Log(enemiesToSpawn.Count);
        Debug.Log(waveDuration / enemiesToSpawn.Count);
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randomEnemyId = Random.Range(0, enemies.Count);
            int randomEnemyCost = enemies[randomEnemyId].GetComponent<EnemyInterface>().GetCost();

            if (waveValue - randomEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randomEnemyId]);
                waveValue -= randomEnemyCost; 
            }
            else if (waveValue < 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }


}
