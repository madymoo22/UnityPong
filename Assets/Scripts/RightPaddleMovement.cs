using UnityEngine;

public class RightPaddleMovement : PaddleMovement
{
    protected override float GetMovementInput()
    {
        if (!IsOwner) return 0f;
        
        return Input.GetAxis("RightPaddleVertical");
    }

}
