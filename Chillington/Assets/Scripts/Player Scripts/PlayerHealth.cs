using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HealthBar;
    public int Health = 10;

    public float newWidthUI = 296.65f;
    public float height = 41.168f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
