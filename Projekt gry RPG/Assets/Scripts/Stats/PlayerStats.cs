using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Player;
using System;

public class PlayerStats : CharacterStats
{
    [SerializeField] private GameObject DeathPanel;
    Player player;
    public event System.Action<double, double> OnHealthChanged;

    [SerializeField]
    private TMP_Text HealthText, DamageText, ArmorText, RangeText, SpeedText, levltext, exptext;
    public PlayerStats() : base()
    {
    }
    // Start is called before the first frame update
    void Awake()
    {
        player = Player.Instance;
        armor = player.armor;
        damage = player.damage;
        attackRange = player.attackRange;
        attackRate = player.attackRate;
        maxhealth = player.maxhealth;
        currentHealth = player.currentHealth;

        player.StatsUpdateEvent += updateStats;
        updateStats();
    }

    public void updateStats()
    {
        player = Player.Instance;
        armor = player.armor;
        damage = player.damage;
        attackRange = player.attackRange;
        attackRate = player.attackRate;
        maxhealth = player.maxhealth;
        Debug.Log(player.currentHealth);
        currentHealth = Math.Min(currentHealth,maxhealth.getValue());
        updateStatsInInventory();
    }

    public void updateStatsInInventory()
    {
        ArmorText.text = Armor.ToString();
        DamageText.text = Damage.ToString();
        RangeText.text = AttackRange.ToString();
        SpeedText.text = AttackRate.ToString();
        RangeText.text = AttackRange.ToString();
        levltext.text = player.Level.ToString();
        exptext.text = player.CurrentExp + "/" + player.NeededExp.ToString();

        HealthText.text = currentHealth.ToString() + "/" + MaxHealth.ToString()   ;

    }

    //implementacja metody Die()
    public override void Die()
{
    currentHealth = MaxHealth;
    DeathPanel.SetActive(true);
}

    //implementacja metody Hurt()
    public override void Hurt()
    {

        {
        base.Hurt();
        Player.Instance.currentHealth = currentHealth;
        //hurt animation
        // animator.SetTrigger("Hurt");
        HealthText.text = MaxHealth.ToString() + "/" + currentHealth.ToString() ;
        if (OnHealthChanged != null)
        {
                    Debug.Log("jest pasek przesyłanie obrażeń");
            OnHealthChanged(MaxHealth, currentHealth);
        }
        }

    }


        public override void TakeDamage(double damage)
        {


        currentHealth -= (damage- Armor);
        Hurt();

             player = Player.Instance;
             player.currentHealth = player.maxhealth.getValue();


           if(currentHealth <= 0)
           {
             Die();
           }
    }
}
