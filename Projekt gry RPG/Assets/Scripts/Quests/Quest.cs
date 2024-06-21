using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable] 
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
    public string newQuestInfo;

    public int itemsToCollect;
    public int itemsCollected;

    public Quest()
    {
        title = "New Quest";
        description = "Description of the quest.";
        newQuestInfo = "Info about the new quest.";
        itemsToCollect = 0;
        itemsCollected = 0;
    }

    public Quest(string title, string description, string newQuestInfo, int itemsToCollect, int itemsCollected)
    {
        this.title = title;
        this.description = description;
        this.newQuestInfo = newQuestInfo;
        this.itemsToCollect = itemsToCollect;
        this.itemsCollected = itemsCollected;
    }

}