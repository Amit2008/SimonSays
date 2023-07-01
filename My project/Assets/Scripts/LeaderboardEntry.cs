using System;

/// <summary>
/// The LeaderboardEntry class represents an entry in the leaderboard, containing a score and a player name.
/// </summary>
[Serializable]
public class LeaderboardEntry
{
    public int score;
    public string playerName;

    /// <summary>
    /// Initializes a new instance of the LeaderboardEntry class with the provided score and player name.
    /// </summary>
    /// <param name="score">The score for the leaderboard entry.</param>
    /// <param name="playerName">The player name for the leaderboard entry.</param>
    public LeaderboardEntry(int score, string playerName)
    {
        this.score = score;
        this.playerName = playerName;
    }
}

