using System.Data;
using UnityEngine;

public class WorldItem : InteractableProp
{
    [Header("CONFIG")]
    [SerializeField] ItemData itemData;


    public override void ProcessInteraction()
    {
        //adds item to player inventory and destroys world version of the item
        PlayerInventory.instance.AddItemToInventory(itemData);
        Destroy(transform.parent.gameObject);
    }

}
