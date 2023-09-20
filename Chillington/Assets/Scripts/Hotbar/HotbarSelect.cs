using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarSelect : MonoBehaviour
{
    public GameObject Selector;
    public Vector3[] SlotPositions;
    private int selectedSlot = 0;

    void Start()
    {

        SlotPositions = new Vector3[7];
        
        SlotPositions[0] = new Vector3(317, 90, 0);
        SlotPositions[1] = new Vector3(393, 90, 0);
        SlotPositions[2] = new Vector3(470, 90, 0);
        SlotPositions[3] = new Vector3(547, 90, 0);
        SlotPositions[4] = new Vector3(623, 90, 0);
        SlotPositions[5] = new Vector3(700, 90, 0);
        SlotPositions[6] = new Vector3(777, 90, 0);

    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            selectedSlot = 0;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("2"))
        {
            selectedSlot = 1;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("3"))
        {
            selectedSlot = 2;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("4"))
        {
            selectedSlot = 3;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("5"))
        {
            selectedSlot = 4;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("6"))
        {
            selectedSlot = 5;
            MoveSelectorToSlot();
        }

        if (Input.GetKeyDown("7"))
        {
            selectedSlot = 6;
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

