using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardCreator : MonoBehaviour 
{
    [SerializeField] private GameObject leaderboardEntryPrefab;
    [SerializeField] private RectTransform container;
    [SerializeField] private LeaderboardScreen leaderboardScreen;
    private void OnEnable()
    {
        CreateLeaderboard();
    }

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
