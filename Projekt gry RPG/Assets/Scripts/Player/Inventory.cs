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

        public event Action onInventoryChanged;
        public int Capacity { get; private set; } = 20;
        public int UsedSpace { get; private set; } = 0;
        public List<Item> Items { get; private set; }

        public Inventory()
        {
            Items = new List<Item>(Capacity);
        }
        public bool AddItemToInv(Item item)
        {
            if (item == null)
                return false;
            Debug.Log(item.name + " added to inventory");
            if (UsedSpace >= Capacity)
            {
                return false;
            }
            else
            {
                Items.Add(item);
                UsedSpace++;
                onInventoryChanged();
                Debug.Log(item.name + " added succesfully");
                return true;
            }
        }
        public void ClearItemsFromInv()
        {
            Items.Clear();
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
            onInventoryChanged();
            return item;
        }
        public Item TakeItem(Item item)
        {
            Items.Remove(item);
            onInventoryChanged();
            return item;
        }
        public bool HasItem(string itemName)
        {
            return Items.Any(x => x.name == itemName);
        }

    }
}
