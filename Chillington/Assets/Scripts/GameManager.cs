using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("HUD")]
    public GameObject HUD;
    public TextMeshProUGUI enemyCounter;
    public GameObject crafting;
    //work pls

    public EnemyAI EnemyAI;
    public GameObject enemies;
    public FieldOfView fov;
    public int enemyCount = 4;
    public static List<Object> enemyList = new List<Object>();

    public bool inEnemyFOV;

    public static GameManager instance;




    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        EnemyAI.deadMan = false;
    }

    void Update()
    {
        if (Input.GetKey)

        if (EnemyAI.deadMan == true)
        {
            SceneManager.LoadScene("Menu");
        }

        ChangeText();
    }

    public void EnemySpawned(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public void EnemyDestroyed(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }

    public void PlayerCaught()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ChangeText()
    {
        enemyCounter.SetText("Enemies: " + enemyList.Count);
    }





}