using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Player;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ItemEffects/EffectHealPlayer")]
public class EffectHealPlayer : AItemEffect
    {
        public int HealValue = 10;
        public override void MakeEffect()
        {
            var player = GameObject.Find("Capsule");
            var stats = player?.GetComponentInChildren<PlayerStats>();
            if (stats != null)
            {
                Debug.LogError("uleczono gracza o 10");
                stats.currentHealth += HealValue;
            }
            else
                Debug.LogError("Nie znaleziono Capsule->PlayerStats");
        }
    }

