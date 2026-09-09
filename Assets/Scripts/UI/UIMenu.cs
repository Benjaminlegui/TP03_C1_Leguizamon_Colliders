using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Buttons")]
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button creditsBackButton;

    protected virtual void Awake()
    {
        settingsButton.onClick.AddListener(ShowSettings);
        creditsButton.onClick.AddListener(ShowCredits);
        settingsBackButton.onClick.AddListener(ShowMain);
        creditsBackButton.onClick.AddListener(ShowMain);
    }

    protected virtual void OnDestroy()
    {
        settingsButton.onClick.RemoveAllListeners();
        settingsBackButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
        creditsBackButton.onClick.RemoveAllListeners();
    }

    public void ShowMain()
    {
        ShowPanel(mainPanel);
    }

    public void ShowSettings()
    {
        ShowPanel(settingsPanel);
    }

    public void ShowCredits()
    {
        ShowPanel(creditsPanel);
    }

    public void ShowPanel(GameObject selectedPanel)
    {
        mainPanel.SetActive(selectedPanel == mainPanel);
        settingsPanel.SetActive(selectedPanel == settingsPanel);
        creditsPanel.SetActive(selectedPanel == creditsPanel);
    }
}
