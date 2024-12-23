using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sun : MonoBehaviour
{
    [SerializeField] GameObject youDiedScreen;
    int currentIndex;

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ship")
        {
            youDiedScreen.SetActive(true);
        }
    }

    public void OnRetryClicked()
    {
        SceneManager.LoadScene(currentIndex);
        youDiedScreen.SetActive(false);
    }
}
