using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{

    InteractableProp interactionTarget;

    void InteractWithTarget()
    {
        interactionTarget.ProcessInteraction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactionTarget = other.GetComponent<InteractableProp>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactionTarget = null;
        }
    }

    public void OnInteract()
    {

        if (interactionTarget != null)
        {
            interactionTarget.ProcessInteraction();
        }
    }

}
