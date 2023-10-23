using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GeneratorHealth : MonoBehaviour
{
    public int Health = 50;
    public TMP_Text deathTexts;

    public GameObject deathScreen;


    public GameObject waveScript;
    private WaveCycleManager waveCycleManager;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("WHy");
        waveCycleManager = waveScript.GetComponent<WaveCycleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            deathScreen.SetActive(true);
            deathTexts.text = "Waves: " + waveCycleManager.cycleCount;
            waveCycleManager.timeOfDay = 12f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            //SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hittable"))
        {
            Debug.Log("ouchy");
            Health = Health - 1;
        }
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
