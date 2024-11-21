using System.Data;
using UnityEngine;

public class WorldItem : InteractableProp
{
    [Header("CONFIG")]
    [SerializeField] InventoryItem inventoryItem;


    public override void ProcessInteraction()
    {
        //adds item to player inventory and destroys world version of the item
        PlayerInventory.instance.AddItemToInventory(inventoryItem);
        Destroy(transform.parent.gameObject);
    }

}
