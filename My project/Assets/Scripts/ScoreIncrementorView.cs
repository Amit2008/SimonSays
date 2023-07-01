using TMPro;
using UnityEngine;

/// <summary>
/// Updates the score text displayed in the associated view.
/// </summary>
public class ScoreIncrementorView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    /// <summary>
    /// Sets the score value in the view.
    /// </summary>
    /// <param name="score">The score to be displayed.</param>
    public void SetScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
}
