using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarSelect : MonoBehaviour
{
    public GameObject Selector;
    public Vector3[] SlotPositions;
    private int selectedSlot = 0;

    public GameObject gun;
    public string Shoot;

    public GameObject knife;
    public string melee;


    void Start()
    {
        (gun.GetComponent(Shoot) as MonoBehaviour).enabled = false;
        (knife.GetComponent(melee) as MonoBehaviour).enabled = true;

        SlotPositions = new Vector3[7];
        
        SlotPositions[0] = new Vector3(551, -27, 0);
        SlotPositions[1] = new Vector3(641, -27, 0);
        SlotPositions[2] = new Vector3(733, -27, 0);
        SlotPositions[3] = new Vector3(826, -27, 0);

    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            (gun.GetComponent(Shoot) as MonoBehaviour).enabled = false;
            (knife.GetComponent(melee) as MonoBehaviour).enabled = true;
            selectedSlot = 0;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("2"))
        {
            (gun.GetComponent(Shoot) as MonoBehaviour).enabled = true;
            (knife.GetComponent(melee) as MonoBehaviour).enabled = false;
            selectedSlot = 1;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("3"))
        {
            (gun.GetComponent(Shoot) as MonoBehaviour).enabled = false;
            (knife.GetComponent(melee) as MonoBehaviour).enabled = false;
            selectedSlot = 2;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("4"))
        {
            (gun.GetComponent(Shoot) as MonoBehaviour).enabled = false;
            (knife.GetComponent(melee) as MonoBehaviour).enabled = false;
            selectedSlot = 3;
            MoveSelectorToSlot();
        }

    }

    void MoveSelectorToSlot()
    {
        // Check if the selected slot is within the SlotPositions array bounds
        if (selectedSlot >= 0 && selectedSlot < SlotPositions.Length)
        {
            // Move the selector to the corresponding position
            Selector.transform.position = SlotPositions[selectedSlot];
        }
    }
}

