using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDItem : MonoBehaviour
{
    TextMeshProUGUI label;
    Image background;

    private void Awake()
    {
        label = GetComponent<TextMeshProUGUI>();
        background = GetComponentInChildren<Image>();
    }

    public void SetText(string newText)
    {
        label.text = newText;
    }

    public void Highlight()
    {
        var highlightedColor = background.color;
        highlightedColor.a = .4f;

        background.color = highlightedColor;
    }

    public void NoHighlight()
    {
        var highlightedColor = background.color;
        highlightedColor.a = 0;

        background.color = highlightedColor;
    }
}
