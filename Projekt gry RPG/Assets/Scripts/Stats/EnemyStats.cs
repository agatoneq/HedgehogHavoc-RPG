using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Assets.Scripts.Player;

public class EnemyStats : CharacterStats
{
    Animator animator;
    public QuestGiver questGiver;
    public int ExpOnKill { get; set; }

    public event System.Action<double, double> OnHealthChanged;
    private void Awake()
    {
        currentHealth = maxhealth.getValue();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();

        QuestGiver[] allQuestGivers = FindObjectsOfType<QuestGiver>();
        foreach (QuestGiver qg in allQuestGivers)
        {
            if (qg.questGiverId == 11 || qg.questGiverId == 15 || qg.questGiverId == 17)
            {
                questGiver = qg;
                break;
            }
        }

        if (questGiver != null)
        {
            Debug.Log("Znaleziono QuestGiver z ID: 11");
        }
        else
        {
            Debug.Log("Nie znaleziono QuestGiver z ID: 11");
        }

    }
    public override void Hurt()
    {
        base.Hurt();

        //hurt animation
        // animator.SetTrigger("Hurt");
        if (OnHealthChanged != null)
        {
            OnHealthChanged(MaxHealth, currentHealth);
        }
    }
    public override void Die()
    {
        base.Die();

        //ragdoll efect / death animation
        animator.SetTrigger("IsDead");
        Invoke("DestroyObj", 0.5f);

        if (questGiver != null && questGiver.quest != null)
        {

            if (Player.Instance.quest.id == 11)
            {
                questGiver.quest.itemsCollected++;
                Debug.Log("Zabici przeciwnicy: " + questGiver.quest.itemsCollected + "/" + questGiver.quest.itemsToCollect);
                if (questGiver.quest.itemsCollected == questGiver.quest.itemsToCollect)
                {
                    Debug.LogError("Enemy Stats koniec zadania 11.");
                    questGiver.finishQuest();
                }
            }
            else if (Player.Instance.quest.id == 14)
            {
                if (transform.name == "BatEvil")
                {
                    Debug.LogError("Enemy Stats koniec zadania 14.");
                    Debug.Log("Zginal: " + transform.name);
                    questGiver.finishQuest();
                }
            }
            else if (Player.Instance.quest.id == 18)
            {
                if (transform.name == "Rat18")
                {
                    Debug.LogError("Enemy Stats koniec zadania 18.");
                    Debug.Log("Zginal: " + transform.name);
                    questGiver.finishQuest();
                }
            }

        }
        else
        {
            Debug.LogError("Enemy Stats QuestGiver or quest is not set.");
        }
        Player.Instance.AwardExp(ExpOnKill);



    }
    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
