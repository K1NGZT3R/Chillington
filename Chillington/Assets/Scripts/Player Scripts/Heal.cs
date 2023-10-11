using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Heal : MonoBehaviour
{
    public int healsLeft = 3;
    public TMP_Text myText;

    public GameObject otherScript; 
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = otherScript.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(healsLeft > 0 && playerHealth.Health < 10)
            {
                healing();
            }
            else if(playerHealth.Health >= 10)
            {
                Debug.Log("Already full health");
            }
            else
            {
                Debug.Log("No heals left!!");
            }

        }
    }

    private void healing()
    {
        healsLeft = healsLeft - 1;
        myText.text = healsLeft.ToString();

        if (playerHealth.Health == 9)
        {
            playerHealth.Health = playerHealth.Health + 1;
            if (playerHealth.Health <= 2)
            {
                Image healthBarImage = playerHealth.HealthBar.GetComponent<Image>();
                if (healthBarImage != null)
                {
                    healthBarImage.color = Color.red;
                }
            }
            else if (playerHealth.Health >= 3)
            {
                Image healthBarImage = playerHealth.HealthBar.GetComponent<Image>();
                if (healthBarImage != null)
                {
                    healthBarImage.color = new Color(0.277977f, 0.745283f, 0.2495995f);
                }
            }

            playerHealth.newWidthUI = playerHealth.newWidthUI + 29.665f;
            RectTransform rectTransform = playerHealth.HealthBar.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(playerHealth.newWidthUI, playerHealth.height);
            }
        }
        else
        {
            playerHealth.Health = playerHealth.Health + 2;
            if (playerHealth.Health <= 2)
            {
                Image healthBarImage = playerHealth.HealthBar.GetComponent<Image>();
                if (healthBarImage != null)
                {
                    healthBarImage.color = Color.red;
                }
            }
            else if (playerHealth.Health >= 3)
            {
                Image healthBarImage = playerHealth.HealthBar.GetComponent<Image>();
                if (healthBarImage != null)
                {
                    healthBarImage.color = new Color(0.277977f, 0.745283f, 0.2495995f);
                }
            }

            playerHealth.newWidthUI = playerHealth.newWidthUI + 59.33f;
            RectTransform rectTransform = playerHealth.HealthBar.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(playerHealth.newWidthUI, playerHealth.height);
            }
        }
        Debug.Log("Healing");
    }
}
