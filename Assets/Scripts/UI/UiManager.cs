using System;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("UI Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button settingsBackToMainButton;
    [SerializeField] private Button creditsBackToMainButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Slider player1SpeedSlider;
    [SerializeField] private Slider player2SpeedSlider;
    [SerializeField] private TMP_Text player1SpeedText;
    [SerializeField] private TMP_Text player2SpeedText;
    
    [Header("UI Panels")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject menusPanel;
    [SerializeField] private GameObject creditsPanel;
    
    [Header("Player Movement")]
    [SerializeField] private Movement player1MoveSpeed;
    [SerializeField] private Movement player2MoveSpeed;
    
    private bool _isPaused = false;
    private bool _gameStarted = false;
    
    void Awake()
    {
        settingsPanel.SetActive(false);
        if (playButton != null)
        { 
            playButton.onClick.AddListener(PlayButtonOnClick);
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(OpenSettings);
        }

        if (creditsButton != null)
        {
            creditsButton.onClick.AddListener(OpenCredits);
        }

        if (settingsBackToMainButton != null)
        {
            settingsBackToMainButton.onClick.AddListener(() => BackToMainMenu(settingsPanel));
        }
        
        if (creditsBackToMainButton != null)
        {
            creditsBackToMainButton.onClick.AddListener(() => BackToMainMenu(creditsPanel));
        }

        if (player1SpeedSlider != null)
        {
            player1SpeedSlider.onValueChanged.AddListener(value => OnPlayerSpeedChanges(player1MoveSpeed, player1SpeedText, value));
        }

        if (player2SpeedSlider != null)
        {
            player2SpeedSlider.onValueChanged.AddListener(value => OnPlayerSpeedChanges(player2MoveSpeed, player2SpeedText, value));
        }
        if (exitButton != null) 
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    void Update()
    {
        if (!_gameStarted) return;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
            menusPanel.SetActive(_isPaused);
            Time.timeScale = _isPaused ? 0 : 1;
        }
    }

    void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        settingsBackToMainButton.onClick.RemoveAllListeners();
        creditsBackToMainButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        player1SpeedSlider.onValueChanged.RemoveAllListeners();
        player2SpeedSlider.onValueChanged.RemoveAllListeners();
    }
    
    private void BackToMainMenu(GameObject self)
    {
        self.SetActive(false);
        mainPanel.SetActive(true);
    }

    void PlayButtonOnClick()
    {
        menusPanel.SetActive(false);
        playButton.GetComponentInChildren<TMP_Text>().text = "Continue";
        _gameStarted = true;
    }

    void OpenCredits()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    void OpenSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void OnPlayerSpeedChanges(Movement player, TMP_Text text, float value)
    {
        player.MovementSpeed = value;
        text.text = value.ToString("F1");
    }
    
    private void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
