using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [Header("Interaction layers")]
    public LayerMask Stone;
    public LayerMask Wood;
    public LayerMask Metal;
    public LayerMask CarBattery;
    public float PickUpRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, Stone) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hit bit");
        } 
        
        if (Physics.Raycast(ray, out RaycastHit hit, Wood) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hit bit");
        }

        if (Physics.Raycast(ray, out RaycastHit hit, Metal) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hit bit");
        } 
        
        if (Physics.Raycast(ray, out RaycastHit hit, CarBattery) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hit bit");
        }


    }
}
