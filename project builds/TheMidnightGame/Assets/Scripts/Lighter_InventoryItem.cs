using UnityEngine;

public class Lighter_InventoryItem : InventoryItem
{

    [Space]
    [SerializeField] float chanceToLight = 1f/6f;

    Light flameLight;

    protected override void Awake()
    {
        base.Awake();
        flameLight = GetComponentInChildren<Light>();
    }

    public override void Use()
    {
        if (!flameLight.enabled)
        {
            if (Random.Range(0f, 1f) < chanceToLight)
            {
                flameLight.enabled = true;
            }

        }
    }

    public override void Hide()
    {
        base.Hide();
        flameLight.enabled = false;
    }

}
