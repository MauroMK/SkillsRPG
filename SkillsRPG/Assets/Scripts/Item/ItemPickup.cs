using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactible
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        // Add to inventory
        Debug.Log("Picking up " + item.name);
       Inventory.instance.AddItem(item);

        // Remove from the scene
        Destroy(gameObject);
    }
}
