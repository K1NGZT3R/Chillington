using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [Header("Resources")]
    public int wood;
    public int metal;
    public int stone;

    public int carBattery;

    [Header("Items")]
    //Tools
    public int hammer;
    public int machete;

    //Other
    public int landmine;
    public int electricFence;



    public void CraftHammer()
    {
        if (wood == 2 && stone == 1)
        {

        }
    }
}
