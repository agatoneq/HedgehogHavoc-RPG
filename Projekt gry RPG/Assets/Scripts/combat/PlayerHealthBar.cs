using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealthBar : MonoBehaviour
{
    Transform UI;
    Transform healthBar;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        //object of whole player UI
        UI = GameObject.Find("PlayerUI 1").transform;
        if (UI != null)
        {
        }
        else
        {
            Debug.Log("no PlayerUI in scene");
        }
        //this.OnHealthChange is called when player takes damage
        GetComponent<PlayerStats>().OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(double maxHealth, double currentHealth)
    {
        if (healthSlider != null)
        {
            //healthbar fill set based on current player's health percentage.
            double healthPercent = currentHealth / maxHealth;
           // Debug.Log(healthPercent);
            healthSlider.value = (float)healthPercent;

        }
    }
}
