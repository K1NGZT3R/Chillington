using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveSpawner;

public enum EPickupType
{
    EPT_Stone,
    EPT_Metal,
    EPT_Wood,
    EPT_Medkit
}



public class InteractableComp : MonoBehaviour
{
    

    public EPickupType pickupType = EPickupType.EPT_Stone;
    public float amount = 1;


    void OnEnable()
    {

    }

    
}
