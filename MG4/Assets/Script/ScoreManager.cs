using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void OnEnable()
    {
        ScoreTrigger.OnScored += AddPoint;
    }

    void OnDisable()
    {
        ScoreTrigger.OnScored -= AddPoint;
    }

    void AddPoint()
    {
        score++;
        scoreText.text = score.ToString();
    }
}