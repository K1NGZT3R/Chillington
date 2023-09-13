using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("HUD")]
    public GameObject HUD;
    public GameObject crafting;
    //work pls

    [Header("Scripts")]
    public MouseLook ml;

    public static GameManager instance;

    void Start()
    {
        crafting.SetActive(false);
    }

    void Update()
    {
        /*Enable and disble crafting UI
        if (Input.GetKeyUp(KeyCode.Tab) && !crafting.activeSelf)
        {
            crafting.SetActive(true);
            Debug.Log("Active");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            

        if (Input.GetKeyDown(KeyCode.Tab) && crafting.activeSelf)
        {
            crafting.SetActive(false);
            Debug.Log("Inactive");
        } */

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!crafting.activeSelf)
            {
                crafting.SetActive(true);
                Debug.Log("Active");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                ml.enabled = false;
            }
            else
            {
                crafting.SetActive(false);
                Debug.Log("Inactive");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                ml.enabled = true;
            }
        }
            
    }
}