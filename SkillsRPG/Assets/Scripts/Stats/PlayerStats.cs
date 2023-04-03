using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    public override void Die()
    {
        base.Die();
        // Kill the player in some way (respawn him in some place)
        PlayerManager.instance.KillPlayer();
    }

    private void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment)
    {
        if (newEquipment != null)
        {
            damage.AddModifier(newEquipment.damageModifier);
            armor.AddModifier(newEquipment.armorModifier);
        }

        if (oldEquipment != null)
        {
            damage.RemoveModifier(oldEquipment.damageModifier);
            armor.RemoveModifier(oldEquipment.armorModifier);
        }
    }

}
