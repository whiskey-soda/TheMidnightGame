using UnityEngine;

public class Matchbox_Inventory : InventoryItem
{
    [Space]
    [SerializeField] float chanceToLight = 1f / 2f;
    [SerializeField] uint matchCount = 32;

    Light flameLight;

    protected override void Awake()
    {
        base.Awake();
        flameLight = GetComponentInChildren<Light>();
    }

    public override void Use()
    {
        if (matchCount > 0
            && !flameLight.enabled)
        {
            if (Random.Range(0f, 1f) < chanceToLight)
            {
                flameLight.enabled = true;
                 matchCount--;
            }

        }
    }

    public override void Hide()
    {
        base.Hide();
        flameLight.enabled = false;
    }
}
