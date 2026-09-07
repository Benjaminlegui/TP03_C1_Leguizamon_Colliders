using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Settings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerSize = 2f;
    
    [Header("Player Colors")]
    [SerializeField] private Color player1Color = Color.white;
    [SerializeField] private Color player2Color = Color.red;

    public Color Player1Color => player1Color;
    public Color Player2Color => player2Color;

    public float PlayerSpeed => playerSpeed;
    public float PlayerSize => playerSize;

    public void SetPlayerSpeed(float value)
    {
        playerSpeed = value;
    }

    public void SetPlayerSize(float value)
    {
        playerSize = value;
    }
    
    public void SetPlayer1Color(Color value)
    {
        player1Color = value;
    }

    public void SetPlayer2Color(Color value)
    {
        player2Color = value;
    }
}
