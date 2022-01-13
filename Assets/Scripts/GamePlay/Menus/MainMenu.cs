using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }

    public void HandleHelpButtonOnClickEvent() {
        MenuManager.GoToMenu(MenuName.Help);
    }

    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
