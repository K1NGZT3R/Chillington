using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveSpawner;

public class PickupSpawner : MonoBehaviour
{
    public List<SpawnableObjects> spawnableObjects = new();
    public int spawnAmount;
    public float spawnDelay;

    private float spawnTimer;
    private GameObject objectToSpawn;

    private Vector3 origin;
    private Vector3 range;
    private Vector3 randomRange;
    private Vector3 randomCoordinate;

    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);


    
    void Start()
    {
        spawnTimer = spawnDelay;

        origin = transform.position;
        range = transform.localScale / 2.0f;
    }

    
    void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            if (spawnAmount > 0)
            {
                randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          Random.Range(-range.z, range.z));
                randomCoordinate = origin + randomRange;


                objectToSpawn = spawnableObjects[Random.Range(0, spawnableObjects.Count)].spawnObject;
                Instantiate(objectToSpawn, randomCoordinate, Quaternion.identity);
                spawnAmount --;
                spawnTimer = spawnDelay;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    [System.Serializable]
    public class SpawnableObjects
    {
        public GameObject spawnObject; 
    }
}
