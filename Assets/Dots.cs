using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Dots : MonoBehaviour, IPointerClickHandler
{
    private bool buttonGlow = false;
    [SerializeField] PatternTracker patternTracker;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Toggle the glow state
        buttonGlow = !buttonGlow;

        // Update the patternTracker inputPattern list
        if (buttonGlow)
        {
            patternTracker.inputPattern.Add(1); // Add a value to the pattern
        }
        else
        {
            patternTracker.inputPattern.Remove(1); // Remove a value from the pattern
        }

        // Change the button color based on the glow state
        GetComponent<Image>().color = buttonGlow ? Color.red : Color.white;
    }
}
