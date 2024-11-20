using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public List<InventorySlot> inventory;
    [SerializeField] public InventorySlot equippedItem;
    [SerializeField] int currentSlot;
    [SerializeField] int maxSlot;
    [SerializeField] InventorySlot blankSlot;

    private void Start()
    {
        blankSlot.quantity = 0;
        blankSlot.slotType = InteractableProp.ItemType.None;
        blankSlot.item = null;
        equippedItem = blankSlot;
    }

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
            equippedItem = inventory[0];
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
        maxSlot = inventory.Count;
    }

    public void DeleteSlot(InventorySlot chosenSlot)
    {
        inventory.Remove(chosenSlot);
        DetermineCurrentSlot();
        maxSlot -= 1;
        if (inventory.Count <= 0)
        {
            equippedItem = blankSlot;
        }
        else
        {
            equippedItem = inventory[currentSlot];
        }
    }
    
    void OnChangeItem(InputValue input)
    {
        EquipSlot(input);
    }

    public void EquipSlot(InputValue input)
    {
        if (inventory.Count > 0)
        {
            if (input.Get<float>() > 0)
            {
                if (currentSlot >= maxSlot - 1)
                {
                    currentSlot = 0;
                }
                else
                {
                    currentSlot += 1;
                }
            }
            else if (input.Get<float>() < 0)
            {
                if (currentSlot <= 0)
                {
                    currentSlot = maxSlot - 1;
                }
                else
                {
                    currentSlot -= 1;
                }
            }

            equippedItem = inventory[currentSlot];
        }
        else
        {
            Debug.Log("No items in inventory");
        }
    }

    void OnUse(InputValue input)
    {
        if (inventory.Count > 0)
        {
            if (input.isPressed)
            {
                UseItem();
            }
            else
            {
                Debug.Log("Released");
            }
        }
    }

    void UseItem()
    {
        InteractableProp itemScript = inventory[currentSlot].item.GetComponent<InteractableProp>();
        itemScript.ProcessInteraction();
        inventory[currentSlot].quantity -= 1;

        if (inventory[currentSlot].quantity <= 0)
        {
            DeleteSlot(inventory[currentSlot]);
        }
    }

    void DetermineCurrentSlot()
    {

        if(maxSlot - 1 > 0 && currentSlot == maxSlot - 1)
        {
            currentSlot -= 1;
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public InteractableProp.ItemType slotType;
    public GameObject item;
    public int quantity;
}
