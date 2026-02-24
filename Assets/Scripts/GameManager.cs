using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    private NetworkVariable<int> leftScore = new NetworkVariable<int>(0);
    private NetworkVariable<int> rightScore = new NetworkVariable<int>(0);

    private NetworkVariable<bool> gameFinished = new NetworkVariable<bool>(false);

    [SerializeField] private int scoreToWin = 5;
    [SerializeField] private BallMovement ball;

    public void PointForLeft()
    {
        if (IsServer && !gameFinished.Value)
        {
            leftScore.Value++;
            Debug.Log("Left scored " + leftScore.Value);
            CheckWinCondition();

            if (!gameFinished.Value && ball != null)
                ball.ResetBall(true);
        }
    }

    public void PointForRight()
    {
        if (IsServer && !gameFinished.Value)
        {
            rightScore.Value++;
            Debug.Log("Right scored " + rightScore.Value);
            CheckWinCondition();

            if (!gameFinished.Value && ball != null)
                ball.ResetBall(false);
        }
    }

    private void CheckWinCondition()
    {
        if (leftScore.Value >= scoreToWin)
        {
            gameFinished.Value = true;
            Debug.Log("Left wins!");
        }
        else if (rightScore.Value >= scoreToWin)
        {
            gameFinished.Value = true;
            Debug.Log("Right wins!");
        }
    }

    public int GetLeftScore() => leftScore.Value;
    public int GetRightScore() => rightScore.Value;
    public bool IsGameFinished() => gameFinished.Value;
}