using System;

[Serializable]
public class LeaderboardEntry
{
    public int score;
    public string playerName;

    public LeaderboardEntry(int score, string playerName)
    {
        this.score = score;
        this.playerName = playerName;
    }
}
