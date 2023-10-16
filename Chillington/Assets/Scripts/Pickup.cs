using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Raycast")]
    public float pickupRange = 100;
    Camera mainCam;
    public InteractableComp sensedObj = null;

    public Crafting crafting;
    public PlayerHealth heal;

    void Awake()
    {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main;
    }


    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * pickupRange, Color.red);

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            InteractableComp obj = hit.collider.GetComponent<InteractableComp>();
            if (obj)
            {
                sensedObj = obj;
            }
            else
            {
                sensedObj = null;
            }
        }
        else
        {
            sensedObj = null;
        }

        if (Input.GetKeyDown(KeyCode.E) && sensedObj)
        {
            Debug.Log(sensedObj.name);

            if(sensedObj.pickupType == EPickupType.EPT_Wood)
            {
                crafting.wood++;
            }
            if (sensedObj.pickupType == EPickupType.EPT_Metal)
            {
                crafting.metal++;
            }
            if (sensedObj.pickupType == EPickupType.EPT_Stone)
            {
                crafting.stone++;
            }
            if (sensedObj.pickupType == EPickupType.EPT_Medkit)
            {
                heal.healsLeft++;
            }

            DestroyImmediate(sensedObj.gameObject);
        }
    }

    
}
