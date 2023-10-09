using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting : MonoBehaviour
{
    [Header("Resources")]
    public TMP_Text woodT;
    public TMP_Text metalT;
    public TMP_Text stoneT;

    public int wood;
    public int metal;
    public int stone;

    [Header("Items")]
    //Tools
    public int knife;
    public int machete;
    public int sword;
    
    //Base Upgrades
    public int traps;
    public int fence;


    private void Update()
    {
        woodT.text = ("Wood: " + wood.ToString());
        metalT.text = ("Wood: " + metal.ToString());
        stoneT.text = ("Wood: " + stone.ToString());
    }

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

    public void CraftTraps()
    {
        if (stone >= 10 && metal >= 10)
        {
            traps = traps + 1;
            stone = stone - 10;
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
}
