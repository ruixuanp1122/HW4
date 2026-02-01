using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void OnEnable()
    {
        ScoreTrigger.OnScored += AddScore;
    }

    void OnDisable()
    {
        ScoreTrigger.OnScored -= AddScore;
    }

    void AddScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}