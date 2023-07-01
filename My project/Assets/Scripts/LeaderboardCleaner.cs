using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The LeaderboardCleaner class is responsible for clearing the leaderboard UI when disabled.
/// </summary>
public class LeaderboardCleaner : MonoBehaviour
{
    private void OnDisable()
    {
        ClearLeaderboardList();
    }

    /// <summary>
    /// Clears the leaderboard UI by destroying all child game objects.
    /// </summary>
    private void ClearLeaderboardList()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}

