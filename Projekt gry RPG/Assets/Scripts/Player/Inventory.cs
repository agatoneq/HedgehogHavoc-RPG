using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Inventory
    {
        public int Capacity { get; private set; } = 20;
        public int UsedSpace { get; private set; } = 0;
        List<Item> Items  = new List<Item>();
        public bool AddItem(Item item)
        {
            if (UsedSpace >= Capacity)
            {
                return false;
            }
            else
            {
                Debug.Log( item.name+ " added to inventory" );
                Items.Add(item);
                UsedSpace++;
                return true;
            }
        }
        public Item FindItem(string name)
        {
            var item = Items.First(x => x.name==name);
            return item;
        }
        public Item TakeItem(string name)
        {
            var item = Items.First(x => x.name == name);
            Items.Remove(item);
            return item;
        }
    }
}
