using Unity.Netcode;
using UnityEngine;

public class PlayerPaddle : PaddleMovement
{
    protected override float GetMovementInput()
    {
        if (!IsOwner) return 0f;

        return IsServer
            ? Input.GetAxis("LeftPaddleVertical")
            : Input.GetAxis("RightPaddleVertical");
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        bool isHostPlayer = OwnerClientId == NetworkManager.ServerClientId;

        Vector3 p = transform.position;
        p.x = isHostPlayer ? -7.5f : 7.5f;
        transform.position = p;

        if (IsOwner)
            netY.Value = transform.position.y;
    }
}

