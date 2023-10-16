using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

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
    public GameObject traps;
    public GameObject fence;

    public GameObject groundFenced;
    public GameObject ground;


    private void Start()
    {
        groundFenced.SetActive(false);
        traps.SetActive(false);
    }

    private void Update()
    {
        woodT.text = ("Wood: " + wood.ToString());
        metalT.text = ("Metal: " + metal.ToString());
        stoneT.text = ("Stone: " + stone.ToString());
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
            stone = stone - 10;
            metal = metal - 10;

            traps.SetActive(true);
        }
    }
    
    public void CraftFence()
    {
        if (metal >= 10)
        {
            metal = metal - 10;

            fence.SetActive(true);

            groundFenced.SetActive(true);
            ground.SetActive(false);
        }
    }
}
