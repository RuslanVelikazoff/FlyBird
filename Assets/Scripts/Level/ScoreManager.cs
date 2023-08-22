using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int highScore;

    private LevelUIManager levelUIManager;

    public void Initialize()
    {
        levelUIManager = FindObjectOfType<LevelUIManager>();

        levelUIManager.AddScore(score);

        Debug.Log("Score manager initialize");
    }

    public void AddScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
        }
        levelUIManager.AddScore(score);
    }
}
