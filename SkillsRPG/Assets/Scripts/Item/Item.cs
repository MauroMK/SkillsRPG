using UnityEngine;


[CreateAssetMenu(fileName = "Create new item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name = "First Item";  // Name of the item
    public Sprite icon = null;              // Item icon
    public bool isDefaultItem = false;      // is the item default wear?

    public virtual void Use()
    {
        // Use the item

        // Something happen, maybe drop on the ground or something

        Debug.Log("Using " + name);
    }

    public virtual void RemoveFromInventory()
    {
        // Removes the item from inventory when used (equiped, dropped, etc)
        Inventory.instance.RemoveItem(this);
    }
}
