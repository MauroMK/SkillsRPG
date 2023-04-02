using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot; // Slot to store equipment in
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;           // Increase/decrease in armor
    public int damageModifier;          // Increase/decrease in damage

    //* When pressed in inventory
    public override void Use()
    {
        base.Use();
        
        EquipmentManager.instance.Equip(this);  // Equip the item
        RemoveFromInventory();                  // Remove it from the inventory
    }

}

public enum EquipmentSlot {Head, Chest, Legs, Feet, Hands, Weapon, Shield, Cape, Neck, Ring}
public enum EquipmentMeshRegion {Legs, Arms, Torso};    // Corresponds to body blendshapes