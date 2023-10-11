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

    public GameObject otherScripts;
    private EnemyAI enemyAI;

    Camera mainCam;

    void Awake()
    {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main;
        bangbang.SetActive(false);
        enemyAI = otherScripts.GetComponent<EnemyAI>();
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
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit hit, weaponRange, hittableLayer))
        {
            Debug.Log("You shot something");
        }
        else
        {
            Debug.Log("You missed");
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
