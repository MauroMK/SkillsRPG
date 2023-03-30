using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake() 
    {
        instance = this;    
    }
    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;

    void Start() 
    {
        inventory = Inventory.instance;

        // This is a string array of all of the elements inside the Enum EquipmentSlots
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];        // Initializing the array with the number of slots given by the enum
    }

    public void Equip (Equipment newEquipment)
    {
        // Get the index of the slot the new item is supposed to inserted into
        int slotIndex = (int)newEquipment.equipmentSlot;

        Equipment oldItem = null;       // Item equiped that will be replaced

        if (currentEquipment[slotIndex] != null)
        {
            // Fills the oldItem variable with the current equiped item, and then adds it to the inventory (Swapping items you may say)
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }

        // Is putting the equipment on the right slot index
        currentEquipment[slotIndex] = newEquipment;
    }

}
