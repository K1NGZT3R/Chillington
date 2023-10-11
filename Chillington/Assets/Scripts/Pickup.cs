using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Raycast")]
    public float weaponRange;
    Camera mainCam;

    public int woodCount;
    public int stoneCount;
    public int metalCount;

    void Awake()
    {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main;
    }


    void Update()
    {
        Shoots();
    }

    private void HandleRaycast()
    {
        /*if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit hit, weaponRange, hittableLayer))
        {
            Debug.Log("Hitting a wall");
        }
        else
        {
            Debug.Log("Not hitting a wall");
        }*/
    }

    private void Shoots()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HandleRaycast();
                //bangbang.SetActive(true);
            }
            else
            {
                //bangbang.SetActive(false);
            }
    }
}
