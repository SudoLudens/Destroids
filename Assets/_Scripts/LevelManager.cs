using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private int number = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        number++;
        print(number);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ChangeToSampleScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        print("Game Quit");
        Application.Quit();
    }
    
}
