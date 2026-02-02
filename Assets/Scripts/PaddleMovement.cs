using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
  protected float speed = 5.0f;

    protected virtual void FixedUpdate()
    {
      float input = GetMovementInput();
      Vector3 movement = new Vector3(0f, input * speed * Time.deltaTime, 0f);
      transform.position += movement;
    }

    protected virtual float GetMovementInput()
    {
      return 0f;
    }
}

