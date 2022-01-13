﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Makes everything stop moving in the game.
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
