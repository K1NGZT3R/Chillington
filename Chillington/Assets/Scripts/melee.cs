using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public Collider hitRange;
    public float counting;

    void Start()
    {
        hitRange.enabled = false;

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
