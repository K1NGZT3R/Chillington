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
    public GameObject hotbar;
    //work pls

    [Header("Scripts")]
    public MouseLook ml;

    public static GameManager instance;

    void Start()
    {
        crafting.SetActive(false);
        hotbar.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!crafting.activeSelf)
            {
                crafting.SetActive(true);
                hotbar.SetActive(false);
                Debug.Log("Active");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                ml.enabled = false;
            }
            else
            {
                crafting.SetActive(false);
                hotbar.SetActive(true);
                Debug.Log("Inactive");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                ml.enabled = true;
            }
        }
            
    }
}