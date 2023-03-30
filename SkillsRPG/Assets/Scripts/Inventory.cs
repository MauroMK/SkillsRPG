using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
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

    [SerializeField] private int inventorySpace = 28;
    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    

    public bool AddItem(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventorySpace)
            {
                Debug.Log("No space in inventory");
                return false;
            }

            items.Add(item);

            // Refreshes the inventory
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        // Refreshes the inventory
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
