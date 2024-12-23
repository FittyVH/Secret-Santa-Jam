using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMainMenu : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] GameObject howToPlayScreen;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void OnHowClicked()
    {
        howToPlayScreen.SetActive(true);
    }
}
