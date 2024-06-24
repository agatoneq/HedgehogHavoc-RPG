using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public double id;
    public string title;
    public string description;
    public string newQuestInfo;

    public int itemsToCollect;
    public int itemsCollected;

    public Quest()
    {
        id = 99.0;
        title = "New Quest";
        description = "Description of the quest.";
        newQuestInfo = "Info about the new quest.";
        itemsToCollect = 0;
        itemsCollected = 0;
    }

    public Quest(double id, string title, string description, string newQuestInfo, int itemsToCollect, int itemsCollected)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.newQuestInfo = newQuestInfo;
        this.itemsToCollect = itemsToCollect;
        this.itemsCollected = itemsCollected;
    }

}