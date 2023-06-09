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

    public SkinnedMeshRenderer targetMesh;
    public Equipment[] defaultItems;               // Default items (shirt, hair, shoes, pants)
    Equipment[] currentEquipment;           // Items currently equipped
    Inventory inventory;                    // Reference to the inventory

    SkinnedMeshRenderer[] currentMeshes;

    //* Callback when an item equipped/unequipped
    public delegate void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment);
    public OnEquipmentChanged onEquipmentChanged;

    void Start() 
    {
        inventory = Inventory.instance;

        // This is a string array of all of the elements inside the Enum EquipmentSlots
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];                        // Initializing the array with the number of slots given by the enum

        currentMeshes = new SkinnedMeshRenderer[numberOfSlots];
        EquipDefaultItems();
    }

    //* Equip a new item
    public void Equip(Equipment newEquipment)
    {
        // Get the index of the slot the new item is supposed to inserted into
        int slotIndex = (int)newEquipment.equipmentSlot;                 

        // Handles the item add to the inventory
        // Item equiped that will be replaced
        Equipment oldEquipment = Unequip(slotIndex);          

        //? Callback to update the inventory when equip or unequip an item
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newEquipment, oldEquipment);
        }

        //* Mesh
        SetEquipmentBlendShapes(newEquipment, 100);

        // Is putting the equipment on the right slot index
        currentEquipment[slotIndex] = newEquipment;

        //* Mesh
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;

    }

    //* Unequip item
    public Equipment Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            //* Mesh
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            Equipment oldEquipment = currentEquipment[slotIndex];   // Item equiped that will be removed
            
            SetEquipmentBlendShapes(oldEquipment, 0);               //* Mesh

            inventory.AddItem(oldEquipment);                        // Removing the item equipped and adding to the inventory

            currentEquipment[slotIndex] = null;                 // Saying that the slot is now empty and ready to equip something
            
            //? Callback to update the inventory when equip or unequip an item
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldEquipment);
            }

            return oldEquipment;
        }

        return null;

    }

    public void UnequipAll()
    {
        //? Maybe use this to stash all the equiped items into the bank

        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItems();
    }

    // This function fixed those armor parts that get eaten by the body
    void SetEquipmentBlendShapes(Equipment equipment, int weight)
    {
        foreach (EquipmentMeshRegion blendshape in equipment.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendshape, weight);
        }
    }

    void EquipDefaultItems()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item);
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }    
    }

}
