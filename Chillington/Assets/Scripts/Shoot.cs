using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bangbang;

    [Header("Raycast")]
    [SerializeField] LayerMask hittableLayer;
    [SerializeField] float weaponRange;

    [SerializeField] float shootDelay = 1f;
    float T_ShootDelay;

    Camera mainCam;

    void Awake()
    {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main;
        bangbang.SetActive(false);
    }

    void Start()
    {
        T_ShootDelay = shootDelay;
    }

    void Update()
    {
        if (T_ShootDelay < shootDelay)
        {
            T_ShootDelay += Time.deltaTime;
        }

        if (T_ShootDelay >= shootDelay)
        {
            T_ShootDelay = 0;
            Shoots();
        }

    }

    private void HandleRaycast()
    {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit hit, weaponRange, hittableLayer))
        {
            Debug.Log("Hitting a wall");
        }
        else
        {
            Debug.Log("Not hitting a wall");
        }
    }

    private void Shoots()
    {
        if (Input.GetMouseButton(0))
        {
            HandleRaycast();
            bangbang.SetActive(true);

        }
        else
        {
            bangbang.SetActive(false);
        }
    }





}
