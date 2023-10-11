using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bangbang;

    [Header("Raycast")]
    [SerializeField] LayerMask hittableLayer;
    [SerializeField] float weaponRange;

    public float timer = 0f;
    public bool countDown = false;
    public int damageAmount = 1;

    Camera mainCam;

    void Awake()
    {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main;
        bangbang.SetActive(false);
    }


    void Update()
    {
        if (countDown == true)
        {
            timer -= Time.deltaTime;
        }
        Shoots();
    }

    private void HandleRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Check if the raycast hit an enemy
            if (hit.collider.gameObject.tag == "Hittable")
            {
                Debug.Log("Hit an enemy!");

                // Get the Enemy component
                EnemyAI enemyAI = hit.collider.gameObject.GetComponent<EnemyAI>();

                // Call the TakeDamage method to decrease the enemy's health
                enemyAI.TakeDamage(damageAmount);
            }
        }
    }

    private void Shoots()
    {
        if (timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                HandleRaycast();
                bangbang.SetActive(true);
                Counter();
            }
            else
            {
                bangbang.SetActive(false);
            }

        }
        bangbang.SetActive(false);

    }

    private void Counter()
    {
        timer = 0.5f;
        countDown = true;
    }





}
