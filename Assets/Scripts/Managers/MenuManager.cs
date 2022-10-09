using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get { return instance; } }
    public bool pauseMenuOn;
    
    [SerializeField] private GameObject pauseMenu;
    private static MenuManager instance;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu == null)
            {
                return;
            }

            if (pauseMenuOn)
            {
                pauseMenu.SetActive(false);
                pauseMenuOn = false;
                Debug.Log("hi");
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pauseMenu.SetActive(true);
                pauseMenuOn = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
