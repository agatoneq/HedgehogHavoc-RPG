using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public class Player
    {
        //dać wartości bazowe!!
        public Stat damage = new Stat(20);
        public Stat maxhealth = new Stat(100);
        public double currentHealth { get; private set; }
        public double currentQuest = 0;
        //armor not implemented yet
        public Stat armor = new Stat(0);
        public Stat attackRange = new Stat(3);
        public Stat attackRate = new Stat(1);
        private static Player instance;
        public Inventory Inventory { get; }
        public Equipment Equipment { get; }
        public List<Character> characters = new List<Character>();

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

        private Player() 
        {
            Inventory = new Inventory();
            Equipment = new Equipment();
        }

    }
}
