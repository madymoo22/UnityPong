using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(speed, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
        {
        Vector2 normal = collision.contacts[0].normal;
        rb.velocity = Vector2.Reflect(rb.velocity, normal);
        } 
}
