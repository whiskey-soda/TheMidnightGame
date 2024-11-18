using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class InteractablePrompt : MonoBehaviour
{
    //needed for positioning prompt above the prop collider
    Collider propCollider;

    RectTransform rectTransform;

    Vector3 propTop;
    float unitsAboveProp = .151f;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        propCollider = transform.parent.GetComponentInChildren<Collider>();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //apply y offset every frame so that prompt stays above object even if it is rotated
        propTop = propCollider.bounds.center + new Vector3(0, propCollider.bounds.extents.y, 0);
        rectTransform.position = propTop + new Vector3(0, unitsAboveProp, 0);

        //face camera at all times
        transform.LookAt(Camera.main.transform.position);
    }
}
