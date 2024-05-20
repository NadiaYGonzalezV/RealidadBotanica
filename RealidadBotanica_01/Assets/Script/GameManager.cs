using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action OneMainMenu;
    public event Action OnitemsMenu;
    public event Action OnARposition;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject );
        }
        else
        {
            instance = this;
        }
    }

    private void Start() => MainMenu();


    public void MainMenu()
    {
        OneMainMenu?.Invoke();
        Debug.Log("Main Menu Activated");
    }
    public void ItemsMenu()
    {
        OnitemsMenu?.Invoke();
        Debug.Log("Items Menu Activated");
    }
    public void ARPosition()
    { 
        OnARposition?.Invoke();
        Debug.Log("AR Position Activated");
    }
    public void CloseApp()
    {
        Application.Quit();
    }
}
