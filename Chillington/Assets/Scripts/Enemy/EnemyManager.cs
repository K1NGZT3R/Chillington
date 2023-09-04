using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject thisObject;

    public bool alertEnemy;

    void Start()
    {
        GameManager.instance.EnemySpawned(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.EnemyDestroyed(gameObject);
    }
}