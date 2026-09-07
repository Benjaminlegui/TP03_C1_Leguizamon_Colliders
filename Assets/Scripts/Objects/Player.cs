using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Game Settings SO")]
    [SerializeField] private GameSettings settings;
    
    [Header("Internal Components")]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D playerBodyCollider;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private PlayerId playerId;

    [Header("Walls")] 
    [SerializeField] private Collider2D topWall;
    [SerializeField] private Collider2D bottomWall;
    
    [Header("Movement")]
    private float moveSpeed => settings.PlayerSpeed;

    private float direction;
    [SerializeField] private KeyCode moveUp =  KeyCode.W;
    [SerializeField] private KeyCode moveDown  = KeyCode.S;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        playerBodyCollider = GetComponentInChildren<Collider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool up = Input.GetKey(moveUp);
        bool down = Input.GetKey(moveDown);

        direction = (up ? 1f : 0f) - (down ? 1f : 0f);
        
        ApplyColor();
        ScalePlayer();
    }


    void FixedUpdate()
    {
        Vector2 target = body.position + Vector2.up * (direction * moveSpeed * Time.fixedDeltaTime);

        target.y = ClampPlayer(target.y);
        
        body.MovePosition(target);
    }

    private float ClampPlayer(float value)
    {
        float halfHeight = playerBodyCollider.bounds.extents.y;
        float minY = bottomWall.bounds.max.y + halfHeight;
        float maxY = topWall.bounds.min.y  - halfHeight;
        
        return Mathf.Clamp(value, minY, maxY);
    }
    
    private void ScalePlayer()
    {
        Vector3 scale = transform.localScale;
        scale.y = settings.PlayerSize;
        transform.localScale = scale;
    }
    
    private void ApplyColor()
    {
        sprite.color = playerId == PlayerId.Player1
            ? settings.Player1Color
            : settings.Player2Color;
    }
}
