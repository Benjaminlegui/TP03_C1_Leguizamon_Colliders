using UnityEngine;
using UnityEngine.UI;

public class UIExitBtn : MonoBehaviour
{
    private Button button;
    void Awake()
    {
            button = GetComponent<Button>();

            if (button != null)
            {
                button.onClick.AddListener(Exit);
            }
    }

    void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
    
    private void Exit()
    {
        SceneController.Instance.Quit();
    }
}
