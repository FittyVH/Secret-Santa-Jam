using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PatternTracker : MonoBehaviour
{
    public List<int> inputPattern;
    List<int> correctPattern = new List<int> { 1, 1, 1, 1, 1 };

    [SerializeField] GameObject incorrectWindow;
    [SerializeField] GameObject correctWindow;

    // [SerializeField] AudioSource shipAudioSrc;
    // [SerializeField] AudioClip shipUnlocked;

    public void OnButtonClick()
    {  
        if (inputPattern.SequenceEqual(correctPattern))
        {
            correctWindow.SetActive(true);
            // shipAudioSrc.clip = shipUnlocked;
            // shipAudioSrc.Play();
            // shipAudioSrc.loop = false;
        }
        else
        {
            incorrectWindow.SetActive(true);
        }
    }
}
