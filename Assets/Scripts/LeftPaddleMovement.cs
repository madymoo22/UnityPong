using UnityEngine;

public class LeftPaddleMovement : PaddleMovement
{
    protected override float GetMovementInput()
    {
        return Input.GetAxis("LeftPaddleVertical");
    }

}
