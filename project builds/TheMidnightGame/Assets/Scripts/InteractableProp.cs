using TMPro;
using UnityEngine;

public class InteractableProp : MonoBehaviour
{

    GameObject prompt;
    public enum InteractionType { Environment, Item }
    public InteractionType interactionType;
    public enum ItemType { Match, Candle, Lighter, Paper, Salt, None };
    public ItemType type;

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
