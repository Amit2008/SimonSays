using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The LeaderboardScreen class represents a UI component that displays the leaderboard.
/// </summary>
public class LeaderboardScreen : MonoBehaviour
{
    [SerializeField] private GameObject leaderboards;
    [SerializeField] private GameObject noGamesYetObj;

    /// <summary>
    /// Shows the "no games yet" message and the leaderboard UI.
    /// </summary>
    public void ShowNoGamesYet()
    {
        noGamesYetObj.SetActive(true);
        leaderboards.SetActive(true);
    }

    /// <summary>
    /// Exits the leaderboard screen by deactivating the game object.
    /// </summary>
    public void ExitLeaderboard()
    {
        gameObject.SetActive(false);
    }
}

