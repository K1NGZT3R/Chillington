using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public List<SpawnLocations> spawnLocations = new();

    [Header ("-SET IN WAVE MANAGER-")]
    public int currWave = 0;
    public int waveDuration = 0;

    [Header ("-DEBUG-")]
    public Transform spawnLocation;
    public int waveValue;
    private float waveTimer;
    public float spawnInterval;
    public float spawnTimer;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();


    void OnEnable()
    {
        GenerateWave();
    }

   
    void FixedUpdate()
    {
        if(spawnTimer <= 0)
        {
            if(enemiesToSpawn.Count > 0)
            {
                spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)].SpawnTransform;
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }


    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();
        
        spawnInterval = waveDuration / enemiesToSpawn.Count;  // gives a fixed time between each enemy spawn
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if(waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;
    }

    [System.Serializable]
    public class SpawnLocations
    {
        public Transform SpawnTransform;
    }
}
