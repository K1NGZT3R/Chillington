using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bangbang;

    [Header("Raycast")]
    [SerializeField] LayerMask hittableLayer;
    [SerializeField] float weaponRange;

    Camera mainCam;

    void Awake()
    {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main;
        bangbang.SetActive(false);
    }

    void Update()
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





}
