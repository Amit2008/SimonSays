using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LeaderboardView))]
public class LeaderBoardController : MonoBehaviour
{
    private LeaderboardView leaderboardView;

    public void SetLeaderboardEntry(LeaderboardEntry leaderboardEntry)
    {
        if (leaderboardView == null)
            leaderboardView = GetComponent<LeaderboardView>();

        leaderboardView.SetLeaderBoardEntryView(leaderboardEntry.playerName, leaderboardEntry.score.ToString());
    }
}
