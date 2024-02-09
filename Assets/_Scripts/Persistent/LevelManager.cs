using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string _mainMenu;
    public static string MainMenu { get; private set; }

    [SerializeField] private string _levelOne;
    public static string LevelOne { get; private set; }


    private void Awake()
    {
        DontDestroyOnLoad(this);

        MainMenu = _mainMenu;
        LevelOne = _levelOne;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void ChangeToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void ChangeLevel(string targetLevel)
    {
        SceneManager.LoadScene(targetLevel);
    }

    public void QuitGame()
    {
        print("Game Quit");
        Application.Quit();
    }
    
}
