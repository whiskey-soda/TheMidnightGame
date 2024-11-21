using TMPro;
using UnityEngine;

public class InteractableProp : MonoBehaviour
{

    GameObject prompt;

    protected virtual void Awake()
    {
        prompt = transform.parent.GetComponentInChildren<InteractablePrompt>(true).gameObject;
    }

    void ShowPrompt()
    {
        prompt.SetActive(true);
    }

    void HidePrompt()
    {
        prompt.SetActive(false);
    }

    // this gets overwritten by derived classes
    public virtual void ProcessInteraction()
    {
        Debug.Log("Interaction detected");
    }

    private void OnTriggerEnter(Collider other)
    {
        //shows prompt if player's interaction field collides with it
        if (other.gameObject.layer == 8)
        {
            ShowPrompt();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //hides prompt if player's interaction field collides with it
        if (other.gameObject.layer == 8)
        {
            HidePrompt();
        }
    }

}
