using UnityEngine;

/// <summary>
/// The HighScoreSaver class is responsible for saving the player's high score to the leaderboard.
/// </summary>
public class HighScoreSaver
{
    private ScoreIncrementorController scoreIncrementor;

    /// <summary>
    /// Initializes a new instance of the HighScoreSaver class with a reference to the ScoreIncrementorController.
    /// </summary>
    /// <param name="scoreIncrementor">The ScoreIncrementorController instance to use for retrieving the player's score.</param>
    public HighScoreSaver(ScoreIncrementorController scoreIncrementor)
    {
        this.scoreIncrementor = scoreIncrementor;
    }

    /// <summary>
    /// Saves the player's high score to the leaderboard by retrieving the score from ScoreIncrementorController
    /// and the player's name from PlayerPrefs, then calling the LeaderboardSystem's SavePlayerWin method.
    /// </summary>
    public void SaveHighScore()
    {
        int score = scoreIncrementor.Score;
        string playerName = PlayerPrefs.GetString(GameConstants.PlayerNameKey, GameConstants.DefaultPlayerName);
        LeaderboardSystem.SavePlayerWin(score, playerName);
    }
}

