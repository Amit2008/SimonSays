using System;
using UnityEngine;

/// <summary>
/// The LeaderboardButtonView class represents a UI component for the leaderboard button.
/// </summary>
public class LeaderboardButtonView : MonoBehaviour
{
    public Action LeaderBoardButtonClicked;

    /// <summary>
    /// Invokes the LeaderBoardButtonClicked event when the leaderboard button is clicked.
    /// </summary>
    public void OnLeaderBoardClick()
    {
        LeaderBoardButtonClicked?.Invoke();
    }
}

