using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
  public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float input = Input.GetAxis("Vertical");
      Vector3 movement = new Vector3(0f, input * speed * Time.deltaTime, 0f);
      transform.position += movement;
    }
}
