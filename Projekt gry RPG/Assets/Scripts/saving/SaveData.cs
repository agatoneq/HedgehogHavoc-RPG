using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public PlayerData MyPlayerData { get;  set; }
    public InventoryData MyInventoryData { get; set; }
    public EquipmentData MyEquipmentData { get; set; }
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
    public int SkillPoint { get; private set; }
    public int Level { get; private set; }
    public int CurrentExp { get; private set; }
    public int NeededExp { get; private set; }
    public PlayerData(Stat damage, Stat maxHealth, Stat armor, Stat attackRange, Stat attackRate,double currentHealth ,
        Vector3 position, Quest quest, int skillPoint, int level, int currentExp, int neededExp)
    {
        this.damage = damage;
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.quest = quest;
        this.armor = armor;
        this.attackRange = attackRange;
        this.attackRate = attackRate;
        this.SkillPoint = skillPoint;
        this.Level = level;
        this.CurrentExp = currentExp;
        this.NeededExp = neededExp;
    }
}
[Serializable]
public class InventoryData
{

    public List<ItemData> items {  get; private set; }
    public InventoryData()
    {
        items = new List<ItemData>();
    }
    public void addItemsData(string name, Sprite icon,  bool isDefaultItem, string desc)
    {
        ItemData item = new ItemData(name, icon,  isDefaultItem, desc);
        items.Add(item);
    }
}
[Serializable]

public class ItemData
{
    public string name { get;  set; }
    public byte[] icon { get; set; }
    public bool isDefaultItem { get; set; }
    public string Desc { get; set; }
    public ItemData(string name, Sprite icon, bool isDefaultItem, string desc)
    {
        this.name = name;
        this.icon = SpriteSerializer.Serialize(icon);
        this.isDefaultItem = isDefaultItem;
        this.Desc = desc;
    }
}

[Serializable]
public class EquipmentData
{
    public EquipmentData()
    {

    }
}


