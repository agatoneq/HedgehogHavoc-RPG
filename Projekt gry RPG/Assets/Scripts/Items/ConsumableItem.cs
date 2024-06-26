using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ConsumableItem")]
    public class ConsumableItem : Item
    {
        [SerializeField]
        public AItemEffect EffectScript;
        
        public ConsumableItem(string name, Sprite icon, bool isDefaultItem, string desc) : base(name, icon, isDefaultItem, desc)
        {
        }
        public override void OnUse()
        {
            base.OnUse();
            EffectScript.MakeEffect();
        }
    }
}
