using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;

    public void Use()
    {
        Debug.Log($"{itemName} has been used");
    }
}
