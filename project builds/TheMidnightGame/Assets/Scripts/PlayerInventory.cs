using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInventory : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] Transform heldItemTransform;


    [Header("DEBUG")]
    public List<InventoryItem> items;
    public InventoryItem equippedItem;
    public int currentSlotIndex;

    public static PlayerInventory instance;

    private void Awake()
    {
        //singleton code
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }

    void OnUse()
    {
        items[currentSlotIndex].Use();
    }

    void OnChangeItem(InputValue input)
    {
        if (items.Any())
        {
            // if trying to go to next slot
            if (input.Get<float>() < 0)
            {
                // if not at max slot
                if (currentSlotIndex > 0)
                {
                    currentSlotIndex--;
                }
            }
            // if trying to go to previous slot
            else if (input.Get<float>() > 0)
            {
                // if not at first slot
                if (currentSlotIndex < items.Count() - 1)
                {
                    currentSlotIndex++;
                }
            }

            EquipSlot(currentSlotIndex);
        }
    }

    void EquipSlot(int slotIndex)
    {
        currentSlotIndex = slotIndex;
        equippedItem = items[slotIndex];

        InventoryUI.instance.UpdateEquippedItem();
    }

    public void AddItemToInventory(ItemData itemData)
    {
        GameObject itemPrefab = Instantiate(itemData.prefab, heldItemTransform);
        InventoryItem itemScript = itemPrefab.GetComponent<InventoryItem>();
        itemScript.itemName = itemData.name;
        items.Add(itemScript);

        InventoryUI.instance.UpdateInventoryHUD();
    }

    public void RemoveItemFromInventory(InventoryItem item)
    {
        Destroy(item.gameObject);

        items.Remove(item);

        if (items.Any()
            && currentSlotIndex > items.Count() - 1)
        {
            currentSlotIndex = items.Count() - 1;
        }

        InventoryUI.instance.UpdateInventoryHUD();
    }

}

