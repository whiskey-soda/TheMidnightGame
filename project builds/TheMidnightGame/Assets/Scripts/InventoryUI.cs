using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] GameObject HUDItemPrefab;

    List<HUDItem> items = new List<HUDItem>();

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

        foreach (HUDItem item in items)
        {
            item.NoHighlight();
        }

        items[PlayerInventory.instance.currentSlotIndex].Highlight();
    }


    public void UpdateInventoryHUD()
    {
        // clear hud
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        items.Clear();

        // creates + configures hud element for all items
        foreach (InventoryItem item in PlayerInventory.instance.items)
        {
            //changes name of object in hierarchy to match the name from the item script
            GameObject uiItemObject = Instantiate(HUDItemPrefab, transform);
            uiItemObject.name = $"{item.itemName} (HUD Item)";


            HUDItem HUDItemScript = uiItemObject.GetComponent<HUDItem>();
            HUDItemScript.SetText(item.itemName);

            items.Add(HUDItemScript);
        }

        UpdateEquippedItem();
    }

}
