using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The LeaderboardSystem class handles operations related to the leaderboard, such as saving player wins and retrieving the leaderboard data.
/// </summary>
public static class LeaderboardSystem
{
    /// <summary>
    /// Saves the player's win by creating a new leaderboard entry, adding it to the leaderboard, sorting the leaderboard, and saving it to PlayerPrefs.
    /// </summary>
    /// <param name="score">The score of the player's win.</param>
    /// <param name="playerName">The name of the player who achieved the win.</param>
    public static void SavePlayerWin(int score, string playerName)
    {
        LeaderboardEntry entry = new LeaderboardEntry(score, playerName);
        List<LeaderboardEntry> leaderboard = GetLeaderboard();
        leaderboard.Add(entry);
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score));
        SaveLeaderboard(leaderboard);
    }

    /// <summary>
    /// Retrieves the current leaderboard data from PlayerPrefs and deserializes it into a list of LeaderboardEntry objects.
    /// If no data is available, it returns an empty list.
    /// </summary>
    /// <returns>The current leaderboard data as a list of LeaderboardEntry objects.</returns>
    public static List<LeaderboardEntry> GetLeaderboard()
    {
        string leaderboardData = PlayerPrefs.GetString(GameConstants.LeaderboardKey, string.Empty);
        if (string.IsNullOrEmpty(leaderboardData))
            return new List<LeaderboardEntry>();

        return JsonConvert.DeserializeObject<List<LeaderboardEntry>>(leaderboardData);
    }

    /// <summary>
    /// Serializes the provided leaderboard data into a JSON string and saves it to PlayerPrefs.
    /// </summary>
    /// <param name="leaderboard">The leaderboard data to be saved.</param>
    private static void SaveLeaderboard(List<LeaderboardEntry> leaderboard)
    {
        string leaderboardData = JsonConvert.SerializeObject(leaderboard);
        PlayerPrefs.SetString(GameConstants.LeaderboardKey, leaderboardData);
        PlayerPrefs.Save();
    }
}

