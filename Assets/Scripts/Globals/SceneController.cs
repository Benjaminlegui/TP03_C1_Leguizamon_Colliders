using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    [SerializeField] private string mainMenu = "MainMenu";
    [SerializeField] private string gameScene = "Game";
    private bool isLoading;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GoToMainMenu();
    }

    private void OnDestroy()
    {
        if(Instance == this) 
            Instance = null;
    }

    public void Play()
    {
        LoadScene(gameScene);
    }

    public void GoToMainMenu()
    {
        LoadScene(mainMenu);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    private void LoadScene(string sceneName)
    {
        if (isLoading)
            return;
        
        StartCoroutine(LoadRoutine(sceneName));
    }

    private IEnumerator LoadRoutine(string sceneName)
    {
        isLoading = true;
        Time.timeScale = 1f;

        try
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
        finally
        {
            isLoading = false;
        }
    }
}
