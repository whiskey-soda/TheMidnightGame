using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]public List<InventorySlot> inventory;
    [SerializeField]public InventorySlot equippedItem;

    public void AddItem(GameObject item)
    {
        InteractableProp itemScript = item.GetComponent<InteractableProp>();
        bool slotFound = false;
        int tempItemID = 0;
        int itemID = 0;
        
        if (inventory.Count > 0)
        {
            foreach(InventorySlot slot in inventory)
            {
                if(slot.slotType == itemScript.type)
                {
                    slotFound = true;
                    itemID = tempItemID;
                }
                tempItemID += 1;
            }

            if(slotFound == true)
            {
                inventory[itemID].quantity += 1;
            }
            else
            {
                CreateSlot(item);
            }
        }
        else
        {
            Debug.Log("interact");
            CreateSlot(item);
        }
    }

    public void CreateSlot(GameObject item)
    {
        InventorySlot slot = new InventorySlot();
        InteractableProp itemScript = item.GetComponent<InteractableProp>();
        slot.slotType = itemScript.type;
        slot.item = item;
        slot.quantity = 1;
        inventory.Add(slot);
    }

    public void DeleteSlot(InventorySlot chosenSlot)
    {
        foreach(InventorySlot slot in inventory)
        {
            if(chosenSlot.slotType == slot.slotType)
            {
                inventory.Remove(slot);
            }
        }
    }

    public void EquipSlot()
    {

    }
}

[System.Serializable]
public class InventorySlot
{
    public InteractableProp.ItemType slotType;
    public GameObject item;
    public int quantity;
}
