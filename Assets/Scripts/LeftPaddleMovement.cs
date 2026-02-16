using UnityEngine;

public class LeftPaddleMovement : PaddleMovement
{
    protected override float GetMovementInput()
    {
        if (!IsOwner) return 0f;

        return Input.GetAxis("LeftPaddleVertical");
    }

}
