using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public Collider hitRange;
    public float counting;

    public GameObject otherScripts;
    private EnemyAI enemyAI;

    void Start()
    {
        hitRange.enabled = false;
        enemyAI = otherScripts.GetComponent<EnemyAI>();
    }


    void Update()
    {
        hits();

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
            Debug.Log("you stabbed something");
        }
    }




}
