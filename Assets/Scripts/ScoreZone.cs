using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public enum ScoreSide { Left, Right }

    [SerializeField] private ScoreSide sideToAward = ScoreSide.Left;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        if (sideToAward == ScoreSide.Left)
            gameManager.PointForLeft();
        else
            gameManager.PointForRight();
    }
}