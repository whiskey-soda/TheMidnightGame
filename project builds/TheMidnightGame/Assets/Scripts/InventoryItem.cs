using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;

    public virtual void Use()
    {
        Debug.Log($"{itemName} has been used");
    }
}
