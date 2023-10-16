using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPickupType
{
    EPT_Stone,
    EPT_Metal,
    EPT_Wood
}

public class InteractableComp : MonoBehaviour
{
    public EPickupType pickupType = EPickupType.EPT_Stone;
    public float amount = 1;
}
