using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] GameObject HUDItemPrefab;

    List<UI_ItemController> uiItems = new List<UI_ItemController>();

    public static InventoryUI instance;

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

    public void UpdateEquippedItem()
    {

        foreach (UI_ItemController item in uiItems)
        {
            item.NoHighlight();
        }

        uiItems[PlayerInventory.instance.currentSlotIndex].Highlight();
    }


    public void UpdateInventoryHUD()
    {
        // clear hud
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        uiItems.Clear();

        // creates + configures hud element for all items
        foreach (InventoryItem item in PlayerInventory.instance.items)
        {
            //changes name of object in hierarchy to match the name from the item script
            GameObject uiItemObject = Instantiate(HUDItemPrefab, transform);
            uiItemObject.name = $"{item.itemName} (HUD Item)";


            // configure the ui element with the item info
            UI_ItemController uiItemController = uiItemObject.GetComponent<UI_ItemController>();
            uiItemController.SetText(item.itemName);

            uiItems.Add(uiItemController);
        }

        UpdateEquippedItem();
    }

}
