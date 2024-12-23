using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool menuOpen = false;

    [SerializeField] GameObject mainMenu;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuOpen = !menuOpen;
        }

        if (menuOpen)
        {
            mainMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(false);
        }
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
