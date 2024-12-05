using UnityEngine;

public class CloakUncloak : MonoBehaviour
{
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    [ContextMenu("cloak")]
    public void Cloak()
    {
        meshRenderer.enabled = false;
    }

    [ContextMenu("uncloak")]
    public void Uncloak()
    {
        meshRenderer.enabled = true;
    }

}
