using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

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

    public void UpdateInventoryHUD()
    {
        // clear hud
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // add hud element for all items
        foreach (InventoryItem item in PlayerInventory.instance.items)
        {
            GameObject HUDItem = new GameObject();
            HUDItem.name = $"{item.name} (HUD Item)";
            HUDItem.transform.parent = transform;
            TextMeshProUGUI text = HUDItem.AddComponent<TextMeshProUGUI>();
            text.text = item.name;
        }
    }

}
