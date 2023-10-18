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

    public GameObject healer;
    public string Heal;

    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject h4;


    void Start()
    {
        (gun.GetComponent(Shoot) as MonoBehaviour).enabled = false;
        (knife.GetComponent(melee) as MonoBehaviour).enabled = true;
        (healer.GetComponent(Heal) as MonoBehaviour).enabled = false;


    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            h1.SetActive(true);
            h2.SetActive(false);
            h3.SetActive(false);
            h4.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            h1.SetActive(false);
            h2.SetActive(true);
            h3.SetActive(false);
            h4.SetActive(false);
        }

        if (Input.GetKeyDown("3"))
        {
            h1.SetActive(false);
            h2.SetActive(false);
            h3.SetActive(true);
            h4.SetActive(false);
        }

        if (Input.GetKeyDown("4"))
        {
            h1.SetActive(false);
            h2.SetActive(false);
            h3.SetActive(false);
            h4.SetActive(true);
        }

    }

   // void MoveSelectorToSlot()
   // {
        // Check if the selected slot is within the SlotPositions array bounds
   //     if (selectedSlot >= 0 && selectedSlot < SlotPositions.Length)
   //     {
            // Move the selector to the corresponding position
    //        Selector.transform.position = SlotPositions[selectedSlot];
    //    }
  //  }
}

