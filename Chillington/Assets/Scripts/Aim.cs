using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private bool isAiming = false;

    public Vector3 hipPos;
    public Vector3 zoomPos;

    public GameObject cam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            AimDownSight();
        }
        else
        {
            isAiming = false;
        }

        if (isAiming == false)
        {
            cam.transform.localPosition = Vector3.MoveTowards(transform.localPosition, hipPos, 10 * Time.deltaTime);
        }
    }

    private void AimDownSight()
    {
        cam.transform.localPosition = Vector3.MoveTowards(transform.localPosition, zoomPos, 10 * Time.deltaTime);
        isAiming = true;
    }
}
