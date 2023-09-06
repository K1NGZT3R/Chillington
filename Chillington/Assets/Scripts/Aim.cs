using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private bool isAiming = false;

    public GameObject cam;
    public Camera cunt;

    public float defaultFOV = 60;


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
            //cam.transform.localPosition = Vector3.MoveTowards(transform.localPosition, hipPos, 10 * Time.deltaTime);
            cunt.fieldOfView = defaultFOV += 120 * Time.deltaTime;
        }

        //Capping FOV
        if (defaultFOV <= 40)
            defaultFOV = 40;

        if (defaultFOV >= 60)
            defaultFOV = 60;
    }

    private void AimDownSight()
    {
        //cam.transform.localPosition = Vector3.MoveTowards(transform.localPosition, zoomPos, 10 * Time.deltaTime);
        cunt.fieldOfView = defaultFOV -= 120 * Time.deltaTime;
        isAiming = true;
    }


}
