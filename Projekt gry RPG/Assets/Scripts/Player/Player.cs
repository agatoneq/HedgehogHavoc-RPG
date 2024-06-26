using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player
{
    public class Player
    {
        public event Action StatsUpdateEvent;
        //dać wartości bazowe!!
        public Stat damage = new Stat(20);
        public Stat maxhealth = new Stat(100);
        public double currentHealth { get; set; } = 100;
        public Quest quest = new Quest();

        //public double currentQuest = 0;
        //armor not implemented yet
        public Stat armor = new Stat(0);
        public Stat attackRange = new Stat(3);
        public Stat attackRate = new Stat(1);
        private static Player instance;
        public Inventory Inventory { get; set; }
        public Equipment Equipment { get; set; }
        public List<Character> characters = new List<Character>();
        public List<GameObject> charactersPanels = new List<GameObject>();

        public int Vitality, Strength, Dexterity;
        public int SkillPoint { get; private set; }
        public int Level { get; private set; }
        public int CurrentExp { get; private set; }
        public int NeededExp { get; private set; } = 1000;
        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }

        }
        public void PlayerLoad(Stat damage, Stat maxHealth, Stat armor, Stat attackRange, Stat attackRate, double currentHealth,
         Quest quest, int skillPoint, int level, int currentExp, int neededExp)
        {
            this.damage = damage;
            this.maxhealth = maxHealth;
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
        private Player()
        {
            Inventory = new Inventory();
            Equipment = new Equipment();
        }
        public void AwardExp(int amount)
        {
            CurrentExp += amount;
            if (NeededExp <= CurrentExp)
            {
                CurrentExp -= NeededExp;
                Level++;
                NeededExp *= (int)(1 + (Level - 1) * 0.5);//z każdym levelem kolejny jest droższy dla lvl = 1 -> 100, lvl = 2 -> 150 ...
                SkillPoint += 2;
            }
        }
    }
}
