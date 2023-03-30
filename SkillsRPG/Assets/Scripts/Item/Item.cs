using UnityEngine;


[CreateAssetMenu(fileName = "Create new item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name = "First Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        // Use the item

        // Something happen, maybe drop on the ground or something

        Debug.Log(name + " used");
    }
}
