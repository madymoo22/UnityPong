using Unity.Netcode;
using UnityEngine;

public abstract class PaddleMovement : NetworkBehaviour, ICollidable
{
    protected float speed = 5.0f;
    protected float minY = -4.35f;
    protected float maxY = 4.35f;
    protected NetworkVariable<float> netY = new NetworkVariable<float>(
        0f,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Owner
    );

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
            netY.Value = transform.position.y;
    }

    protected virtual void FixedUpdate()
    {
        if (!IsSpawned) return;

        if (IsOwner)
        {
            float input = GetMovementInput();

            Vector3 pos = transform.position;
            pos.y += input * speed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;

            netY.Value = pos.y;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y = netY.Value;
            transform.position = pos;
        }
    }

    protected abstract float GetMovementInput();

    public virtual void OnHit(Collision2D collision)
    {
        Debug.Log("Paddle was hit!");
    }
}