using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HealthBar;
    public int Health = 10;
    public int healsLeft = 3;
    public TMP_Text myText;
    public TMP_Text deathTexts;

    public float newWidthUI = 296.65f;
    public float height = 41.168f;
    public GameObject deathScreen;

    public GameObject playerMove;

    public GameObject waveScript;
    private WaveCycleManager waveCycleManager;

    public Heal heal;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("WHy");
        waveCycleManager = waveScript.GetComponent<WaveCycleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = healsLeft.ToString();
        if(Health <= 0)
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
            if(Health <= 2)
            {
                Image healthBarImage = HealthBar.GetComponent<Image>();
                if (healthBarImage != null)
                {
                    healthBarImage.color = Color.red;
                }
            }else if(Health >= 3)
            {
                Image healthBarImage = HealthBar.GetComponent<Image>();
                if (healthBarImage != null)
                {
                    healthBarImage.color = new Color(0.277977f, 0.745283f, 0.2495995f);
                }
            }

            newWidthUI = newWidthUI - 29.665f;
            loseHealth();
        }
    }

    private void loseHealth()
    {
            RectTransform rectTransform = HealthBar.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(newWidthUI, height);
            }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
