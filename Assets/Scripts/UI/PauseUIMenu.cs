using UnityEngine;
using UnityEngine.UI;

public class PauseUIMenu : UIMenu
{
    [SerializeField] private Button continueButton;
    
    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;
    
    private bool isPaused = false;
    
    protected override void Awake()
    {
        base.Awake();
        continueButton.onClick.AddListener(Resume);
    }

    void OnEnable()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        continueButton.onClick.RemoveListener(Resume);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        ShowMain();
    }
}
