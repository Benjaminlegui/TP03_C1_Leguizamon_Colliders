using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 direction = new Vector2(1f, 0.5f).normalized;
        rb.linearVelocity = direction * speed;
    }
}
