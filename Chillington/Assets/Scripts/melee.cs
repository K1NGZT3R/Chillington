using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public Collider hitRange;
    public float counting;

    public GameObject otherScripts;
    private EnemyAI enemyAI;

    public GameObject shootScript;
    private Shoot shoot;

    public int damageAmount = 5;

    void Start()
    {
        shoot = shootScript.GetComponent<Shoot>();
        hitRange.enabled = false;
        enemyAI = otherScripts.GetComponent<EnemyAI>();
    }


    void Update()
    {
        hits();
        if (shoot.killScreen > 0)
        {
            shoot.killScreen = shoot.killScreen - Time.deltaTime;
            shoot.killCred.SetActive(true);
        }
        else
        {
            shoot.killCred.SetActive(false);
        }

    }

    private void hits()
    {

        if (Input.GetMouseButtonDown(0))
        {
            hitRange.enabled = true;
            Debug.Log("stab");
        }
        if (Input.GetMouseButtonUp(0))
        {
            hitRange.enabled = false;
            Debug.Log("no stab");

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hittable"))
        {
            //it dont wanna work, the zombies dont want to die
            Destroy(other.gameObject);
            Debug.Log("you stabbed something");
        }
    }




}
