using UnityEngine;

public abstract class PaddleMovement : MonoBehaviour, ICollidable
{
  protected float speed = 5.0f;

  protected float minY = -4.35f;
  protected float maxY = 4.35f;

    protected virtual void FixedUpdate()
    {
      float input = GetMovementInput();
      Vector3 movement = new Vector3(0f, input * speed * Time.deltaTime, 0f);
      transform.position += movement;

      Vector3 pos = transform.position;
      pos.y = Mathf.Clamp(pos.y, minY, maxY);
      transform.position = pos;
    }

    protected abstract float GetMovementInput();

      public virtual void OnHit(Collision2D collision)
    {
        Debug.Log("Paddle was hit!");
    }

}

