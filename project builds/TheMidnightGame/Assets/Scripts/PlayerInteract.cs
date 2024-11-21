using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    InteractableProp interactionTarget;
    [SerializeField]
    List<GameObject> items;
    public GameObject closestItem;
    public PlayerInventory inventory;

    private void Awake()
    {
        inventory = GetComponentInParent<PlayerInventory>();
    }

    public void Update()
    {
        if (items.Count > 0)
        {
            SortClosestObject();
        }
        else
        {
            closestItem = null;
        }
    }

    void InteractWithTarget()
    {
        interactionTarget.ProcessInteraction();
    }

    void SortClosestObject()
    {
        float lastClosestDistance;
        foreach(GameObject item in items)
        {
            //gets the list length and sets what the last item is to infinity inorder to ensure no item is bigger than the initial closest item
            int itemLength = items.Count;
            lastClosestDistance = Mathf.Infinity;

            //goes through each interactable and determines the closest interactable
            for (int i = 0; i < itemLength; i++)
            {
                //triangulates the actual closest distance using pythag theorum
                Vector3 distanceFromPlayer = items[i].transform.position - transform.parent.position;
                float distance;
                distance = CalculateDistance(distanceFromPlayer);

                //if the current distance is less then the last item then it is the closest
                if (distance < lastClosestDistance)
                {
                    
                    closestItem = items[i];
                    lastClosestDistance = distance;
                }
            }
            lastClosestDistance = Mathf.Infinity;
        }
    }

    public float CalculateDistance(Vector3 distance)
    {
        float pythagDistance;
        pythagDistance = Mathf.Sqrt((distance.x * distance.x) + (distance.y * distance.y) + (distance.z * distance.z));

        return pythagDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            items.Add(other.gameObject);
            interactionTarget = other.GetComponent<InteractableProp>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            items.Remove(other.gameObject);
            interactionTarget = null;
        }
    }

    public void OnInteract()
    {
        if (closestItem != null)
        {
            InteractableProp interactionScript = closestItem.GetComponent<InteractableProp>();
            if (interactionScript.interactionType == InteractableProp.InteractionType.Item)
            {
                //InteractableProp interaction = closestItem.GetComponent<InteractableProp>();
                //interaction.ProcessInteraction();

                inventory.AddItem(closestItem);
            }
            else if (interactionScript.interactionType == InteractableProp.InteractionType.Environment)
            {
                interactionScript.ProcessInteraction();
            }
        }
    }
}
