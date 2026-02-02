using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private float speed = 3f;

    // Public getter/ setter methods 
    public Vector2 Direction
    {
        get { return direction; }
        set { direction = value.normalized; }
    }
    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Direction = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Direction = Vector2.Reflect(direction, normal);
    }
}

