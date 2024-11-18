using TMPro;
using UnityEngine;

public class InteractableProp : MonoBehaviour
{

    GameObject prompt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prompt = transform.parent.GetComponentInChildren<TextMeshPro>(true).gameObject;
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
