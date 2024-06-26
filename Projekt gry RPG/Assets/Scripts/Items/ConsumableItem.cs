using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ConsumableItem")]
    public class ConsumableItem : Item
    {
        [SerializeField]
        public AItemEffect EffectScript;

        public override void OnUse()
        {
            base.OnUse();
            EffectScript.MakeEffect();
        }
    }
}
