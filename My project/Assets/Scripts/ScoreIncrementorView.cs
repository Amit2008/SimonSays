using TMPro;
using UnityEngine;

public class ScoreIncrementorView : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SetScore(int score)
    { 
        scoreText.text = $"Score: {score}";
    }
}