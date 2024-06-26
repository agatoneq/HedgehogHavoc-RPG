using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Player;

public class PlayerStats : CharacterStats
{
    [SerializeField] private GameObject DeathPanel;
    Player player;
    public event System.Action<double, double> OnHealthChanged;

    [SerializeField]
    private TMP_Text HealthText, DamageText, ArmorText, RangeText, SpeedText;

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
        player.Equipment.onEquipmentChanged += EquipmentChanged;

        player.SkillpointEvent += updateStats;
        updateStatsInInventory();
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
        currentHealth = player.currentHealth;

        updateStatsInInventory();
    }

    public void updateStatsInInventory()
    {
        ArmorText.text = Armor.ToString();
        DamageText.text = Damage.ToString();
        RangeText.text = AttackRange.ToString();
        SpeedText.text = AttackRate.ToString();

        HealthText.text = MaxHealth.ToString() + "/" + currentHealth.ToString() ;

    }

    void EquipmentChanged(EquipmentItem newItem, EquipmentItem oldItem)
    {
        if (newItem != null)
        {
            foreach (var m in newItem.ModifierList)
            {
                Stats[m.AffectedStatType].addModifier(m);
            }
        }
        
        if (oldItem != null)
        {
            foreach (var m in newItem.ModifierList)
            {
                Stats[m.AffectedStatType].removeModifier(m);
            }
        }
    }

    //implementacja metody Die()
    public override void Die()
{
    DeathPanel.SetActive(true);
}

    //implementacja metody Hurt()
    public override void Hurt()
    {
        base.Hurt();
        Player.Instance.currentHealth = currentHealth;
        //hurt animation
        // animator.SetTrigger("Hurt");
        HealthText.text = MaxHealth.ToString() + "/" + currentHealth.ToString() ;
        if (OnHealthChanged != null)
        {
            OnHealthChanged(MaxHealth, currentHealth);
        }
    }
}
