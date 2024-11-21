using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    List<InteractableProp> interactablesInRange = new List<InteractableProp>();

    private void Update()
    {
        // removes all null objects from the list
        // null objects appear when an item is destroyed while in range (like when picking worlditems up)
        interactablesInRange.RemoveAll(x => !x);
    }

    public void OnInteract()
    {

        if (interactablesInRange.Any())
        {
            GetClosestInteractable().ProcessInteraction();
        }

    }

    InteractableProp GetClosestInteractable()
    {
        InteractableProp closestInteractable = null;
        float closestDistance = 0;
        foreach (InteractableProp interactable in interactablesInRange)
        {
            float distanceToProp = Vector3.Distance(transform.position, interactable.transform.position);

            if (closestInteractable == null
                || distanceToProp < closestDistance)
            {
                closestInteractable = interactable;
                closestDistance = distanceToProp;
            }
        }

        return closestInteractable;

    }

    private void OnTriggerEnter(Collider other)
    {
        // if interactable is not in list, add interactable to list of interactables in range
        InteractableProp interactableScript = other.GetComponent<InteractableProp>();
        if (interactableScript != null
            && !interactablesInRange.Contains(interactableScript))
        {
            interactablesInRange.Add(interactableScript);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // if interactable is in list, remove interactable from list of interactables in range
        InteractableProp interactableScript = other.GetComponent<InteractableProp>();
        if (interactableScript != null
            && interactablesInRange.Contains(interactableScript))
        {
            interactablesInRange.Remove(interactableScript);
        }
    }


}
