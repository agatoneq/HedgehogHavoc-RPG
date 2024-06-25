using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public PlayerData MyPlayerData { get;  set; }
    public Scene ActiveScene { get; set; }
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
    public PlayerData(Stat damage, Stat maxHealth, Stat armor, Stat attackRange, Stat attackRate,double currentHealth ,Vector2 position)
    {
        this.damage = damage;
        this.maxHealth = maxHealth;
        this.armor = armor;
        this.attackRange = attackRange;
        this.attackRate = attackRate;
        this.currentHealth = currentHealth;
        this.x = position.x;
        this.y = position.y;
    }
}

