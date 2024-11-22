using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;

    GameObject geometry;

    private void Awake()
    {
        geometry = GetComponentInChildren<MeshRenderer>(true).gameObject;
    }

    public virtual void Use()
    {
        Debug.Log($"{itemName} has been used");
    }

    public void Show()
    {
        geometry.SetActive(true);
    }

    public void Hide()
    {
        geometry.SetActive(false);
    }

} 
