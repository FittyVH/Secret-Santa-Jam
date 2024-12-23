using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class WrongDots : MonoBehaviour, IPointerClickHandler
{
    private bool buttonGlow = false;
    [SerializeField] PatternTracker patternTracker;

    public void OnPointerClick(PointerEventData eventData)
    {
        buttonGlow = !buttonGlow;

        if (buttonGlow)
        {
            patternTracker.inputPattern.Add(0); // Add a value to the pattern
        }
        else
        {
            patternTracker.inputPattern.Remove(0); // Remove a value from the pattern
        }

        // Change the button color based on the glow state
        GetComponent<Image>().color = buttonGlow ? Color.red : Color.white;
    }
}
