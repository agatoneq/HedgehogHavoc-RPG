using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyStats))]

public class EnemyHealthBar : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public Transform target;

    Transform healthBar;
    Image healthSlider;

    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        foreach (Canvas c in FindObjectsOfType<Canvas>()) 
        {
            if(c.renderMode == RenderMode.WorldSpace)
            {
                //creating healthbar object
                healthBar = Instantiate(healthBarPrefab, c.transform).transform;
                //getting healthbar slider
                healthSlider = healthBar.GetChild(0).GetComponent<Image>();
                //healthbar not visible
                healthBar.gameObject.SetActive(false);
                break;
            }
        
        }
        //this.OnHealthChange is called when enemy takes damage
        GetComponent<EnemyStats>().OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(double maxHealth, double currentHealth)
    {
        if (healthBar != null)
        {
            //healthbar is visible
            healthBar.gameObject.SetActive(true);
            //calculating healthbar fill based on percentage
            double healthPercent = currentHealth / maxHealth;
            healthSlider.fillAmount = (float)healthPercent;
            if (currentHealth <= 0)
            {
                Destroy(healthBar.gameObject);
            }
        }
    }

    void LateUpdate()
    {
        if (healthBar != null)
        {
            //setting healthbar above enemy
            healthBar.position = target.position;
            healthBar.forward = cam.forward;
            //healthbar is visible only when enemy is in evil mode
            if (GetComponent<Animator>().GetBool("Evil") == true)
            {
                healthBar.gameObject.SetActive(true);
            }
            else
            {
                healthBar.gameObject.SetActive(false);
            }
        }
    }
}
