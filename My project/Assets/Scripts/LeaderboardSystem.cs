using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public static class LeaderboardSystem
{
    public static void SavePlayerWin(int score, string playerName)
    {
        LeaderboardEntry entry = new LeaderboardEntry(score, playerName);
        List<LeaderboardEntry> leaderboard = GetLeaderboard();
        leaderboard.Add(entry);
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score));
        SaveLeaderboard(leaderboard);
    }

    public static List<LeaderboardEntry> GetLeaderboard()
    {
        string leaderboardData = PlayerPrefs.GetString(GameConstants.LeaderboardKey, string.Empty);
        if (string.IsNullOrEmpty(leaderboardData))
            return new List<LeaderboardEntry>();

        return JsonConvert.DeserializeObject<List<LeaderboardEntry>>(leaderboardData);
    }

    private static void SaveLeaderboard(List<LeaderboardEntry> leaderboard)
    {
        string leaderboardData = JsonConvert.SerializeObject(leaderboard);
        PlayerPrefs.SetString(GameConstants.LeaderboardKey, leaderboardData);
        PlayerPrefs.Save();
    }
}
