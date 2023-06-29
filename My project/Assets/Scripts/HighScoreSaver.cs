using UnityEngine;

public class HighScoreSaver 
{
    private ScoreIncrementorController scoreIncrementor;
    public HighScoreSaver(ScoreIncrementorController scoreIncrementor) 
    {
        this.scoreIncrementor = scoreIncrementor;
    }

    public void SaveHighScore()
    {
        int score = scoreIncrementor.Score;
        string playerName = PlayerPrefs.GetString(GameConstants.PlayerNameKey, GameConstants.DefaultPlayerName);
        LeaderboardSystem.SavePlayerWin(score, playerName);
    }
}
