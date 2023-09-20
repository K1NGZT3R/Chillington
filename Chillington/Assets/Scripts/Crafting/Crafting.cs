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
    public int fence;
    public int gate;


    public void CraftHammer()
    {
        if (wood >= 2 && stone >= 1)
        {
            hammer = hammer + 1;
            wood = wood - 2;
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

    public void CraftLandmine()
    {
        if (metal >= 5 && stone >= 10 && wood >= 2)
        {
            landmine = landmine + 1;
            metal = metal - 5;
            stone = stone - 10;
            wood = wood - 2;
        }
    }

    public void CraftElectricFence()
    {
        if (carBattery >= 1 && metal >= 10)
        {
            electricFence = electricFence + 1;
            carBattery = carBattery - 1;
            metal = metal - 10;
        }
    }

    public void CraftFence()
    {
        if (metal >= 10)
        {
            fence = fence + 1;
            metal = metal - 10;
        }
    }

    public void CraftGate()
    {
        if (metal >= 10 && stone >= 2)
        {
            gate = gate + 1;
            metal = metal - 10;
            stone = stone - 2;
        }
    }

//goopy poopie

}
