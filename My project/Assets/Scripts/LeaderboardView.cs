using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// The LeaderboardView class is responsible for displaying a leaderboard entry's data on the UI.
/// </summary>
public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI playerScoreText;

    /// <summary>
    /// Sets the UI elements of the leaderboard entry with the provided player name and score.
    /// </summary>
    /// <param name="playerName">The name of the player for the leaderboard entry.</param>
    /// <param name="playerScore">The score of the player for the leaderboard entry.</param>
    public void SetLeaderBoardEntryView(string playerName, string playerScore)
    {
        playerNameText.text = playerName;
        playerScoreText.text = playerScore;
    }
}

