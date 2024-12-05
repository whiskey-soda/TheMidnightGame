using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;

    GameObject geometry;

    protected virtual void Awake()
    {
        geometry = GetComponentInChildren<MeshRenderer>(true).gameObject;
    }

    public virtual void Use()
    {
        Debug.Log($"{itemName} has been used");
    }

    public virtual void Show()
    {
        geometry.SetActive(true);
    }

    public virtual void Hide()
    {
        geometry.SetActive(false);
    }

} 
