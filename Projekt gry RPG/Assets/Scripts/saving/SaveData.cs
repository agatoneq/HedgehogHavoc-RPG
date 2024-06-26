using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public PlayerData MyPlayerData { get;  set; }
    public int ActiveScene { get; set; }
    public SaveData()
    {

    }
}
[Serializable]
public class PlayerData
{
    public Stat damage { get; set; }
    public Stat maxHealth { get; set; }
    public Stat armor { get; set; }
    public Stat attackRange { get; set; }
    public Stat attackRate { get; set; }
    public double currentHealth { get; set; }
    public float x {  get; set; }
    public float y { get; set; }
    public float z { get; set; }
    public Quest quest { get; set; }
    //public Inventory Inventory { get; }
   // public Equipment Equipment { get; }
    public int SkillPoint { get; private set; }
    public int Level { get; private set; }
    public int CurrentExp { get; private set; }
    public int NeededExp { get; private set; }
    public PlayerData(Stat damage, Stat maxHealth, Stat armor, Stat attackRange, Stat attackRate,double currentHealth ,
        Vector3 position, Quest quest, /*Inventory inventory, Equipment equipment,*/ int skillPoint, int level, int currentExp, int neededExp)
    {
        this.damage = damage;
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.quest = quest;
        this.armor = armor;
        this.attackRange = attackRange;
        this.attackRate = attackRate;
        //this.Inventory = inventory;
        //this.Equipment = equipment;
        this.SkillPoint = skillPoint;
        this.Level = level;
        this.CurrentExp = currentExp;
        this.NeededExp = neededExp;
    }
}


