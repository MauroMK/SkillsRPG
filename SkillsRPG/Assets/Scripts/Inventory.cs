using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    #region Singleton
    public static Inventory instance;

    void Awake() 
    {
        if (instance != null)
        {
            return;
        }

        instance = this;    
    }
    #endregion

    public void AddItem(Item item)
    {
        if (!item.isDefaultItem)
        {
            items.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
