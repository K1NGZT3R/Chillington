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
    public int knife;
    public int machete;
    public int sword;
    //Other
    
    public int spikes;


    public void CraftKnife()
    {
        if (metal >= 2 && stone >= 1)
        {
            knife = knife + 1;
            metal = metal - 2;
            stone = stone - 1;
        }
    }

    public void CraftMachete()
    {
        if (metal >= 2 && wood >= 1)
        {
            machete = machete + 1;
            metal = metal - 2;
            wood = wood - 1;
        }
    }

    public void CraftSword()
    {
        if (metal >= 6 && stone >= 3 && wood >= 3)
        {
            sword = sword + 1;
            metal = metal - 7;
            stone = stone - 3;
            wood = wood - 3;
        }
    }

    public void CraftSpikes()
    {
        if (carBattery >= 1 && metal >= 10)
        {
            spikes = spikes + 1;
            carBattery = carBattery - 1;
            metal = metal - 10;
        }
    }
}
