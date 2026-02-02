using UnityEngine;

public class RightPaddleMovement : PaddleMovement
{
    protected override float GetMovementInput()
    {
        return Input.GetAxis("RightPaddleVertical");
    }

}
