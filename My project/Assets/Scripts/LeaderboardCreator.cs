using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The LeaderboardCreator class is responsible for creating and populating the leaderboard UI with leaderboard entries.
/// </summary>
public class LeaderboardCreator : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardEntryPrefab;
    [SerializeField] private RectTransform container;
    [SerializeField] private LeaderboardScreen leaderboardScreen;

    private void OnEnable()
    {
        CreateLeaderboard();
    }

    /// <summary>
    /// Creates the leaderboard UI by retrieving the leaderboard entries, instantiating leaderboard entry objects,
    /// and setting their data using LeaderBoardController.
    /// </summary>
    private void CreateLeaderboard()
    {
        List<LeaderboardEntry> leaderboardEntries = LeaderboardSystem.GetLeaderboard();
        if (leaderboardEntries == null || leaderboardEntries.Count == 0)
        {
            leaderboardScreen.ShowNoGamesYet();
            return;
        }

        foreach (var leaderboardEntry in leaderboardEntries)
        {
            GameObject entryObj = Instantiate(leaderboardEntryPrefab, container.transform);
            LeaderBoardController leaderboardController = entryObj.GetComponent<LeaderBoardController>();

            if (leaderboardController == null)
            {
                Debug.LogError("CreateLeaderboard: LeaderboardController component is null - error");
                return;
            }

            leaderboardController.SetLeaderboardEntry(leaderboardEntry);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(container);
    }
}

