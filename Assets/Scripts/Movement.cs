using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private KeyCode movementUp = KeyCode.W;
    [SerializeField] private KeyCode movementDown = KeyCode.S;
    [SerializeField] private KeyCode movementLeft = KeyCode.A;
    [SerializeField] private KeyCode movementRight = KeyCode.D;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    
    void Update()
    {
        Move();
        Rotate();
        ChangeColor();
    }

    private void Move()
    {
        float normalizedSpeed = movementSpeed * Time.deltaTime;
        
        // Movement keymaps
        if (Input.GetKey(movementUp))
        {
            transform.position += new Vector3(0, normalizedSpeed);
        }

        if (Input.GetKey(movementLeft))
        {
            transform.position += new Vector3(-normalizedSpeed, 0);
        }

        if (Input.GetKey(movementDown))
        {
            transform.position += new Vector3(0, -normalizedSpeed);

        }

        if (Input.GetKey(movementRight))
        {
            transform.position += new Vector3(normalizedSpeed, 0);
        }
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 10));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -10));
        }
    }

    private void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
