using UnityEngine;
using UnityEngine.UI;

public class UIPlayBtn : MonoBehaviour
{
    private Button button;
    
    void Awake()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(Play);
        }
    }

    void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
    
    private void Play()
    {
        SceneController.Instance.Play();
    }
}
