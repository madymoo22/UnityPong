using UnityEngine;

public class BallMovement : MonoBehaviour, ICollidable
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private float speed = 3f;
 
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Direction = new Vector2(1, 1);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Direction = Vector2.Reflect(direction, normal);

        ICollidable collidable =
            collision.gameObject.GetComponent<ICollidable>();

        if (collidable != null)
        {
            collidable.OnHit(collision);
        }
    }

    public void OnHit(Collision2D collision)
    {
        Debug.Log("Ball was hit!");
    }
}