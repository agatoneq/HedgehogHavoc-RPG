using System.Collections;
using System.Collections.Generic;
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
                healthBar = Instantiate(healthBarPrefab, c.transform).transform;
                healthSlider = healthBar.GetChild(0).GetComponent<Image>();
                healthBar.gameObject.SetActive(false);
                break;
            }
        
        }
        GetComponent<EnemyStats>().OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(double maxHealth, double currentHealth)
    {
        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(true);

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
            healthBar.position = target.position;
            healthBar.forward = cam.forward;
        }

        if (GetComponent<Animator>().GetBool("Evil") == true)
        {
            healthBar.gameObject.SetActive(true);
        }else
        {
            healthBar.gameObject.SetActive(false);
        }
    }
}
