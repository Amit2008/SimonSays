using System.Collections;
using UnityEngine;

/// <summary>
/// The LeaderBoardController class is responsible for controlling the display of a leaderboard entry in the UI.
/// </summary>
[RequireComponent(typeof(LeaderboardView))]
public class LeaderBoardController : MonoBehaviour
{
    private LeaderboardView leaderboardView;

    /// <summary>
    /// Sets the leaderboard entry's view using the LeaderboardView component.
    /// </summary>
    /// <param name="leaderboardEntry">The leaderboard entry to be displayed.</param>
    public void SetLeaderboardEntry(LeaderboardEntry leaderboardEntry)
    {
        if (leaderboardView == null)
            leaderboardView = GetComponent<LeaderboardView>();

        leaderboardView.SetLeaderBoardEntryView(leaderboardEntry.playerName, leaderboardEntry.score.ToString());
    }
}

