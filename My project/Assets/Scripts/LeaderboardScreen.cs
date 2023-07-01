using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardScreen : MonoBehaviour
{
    [SerializeField] private GameObject leaderboards;
    [SerializeField] private GameObject noGamesYetObj;

    private void OnEnable()
    {
        MainMenuEvents.Instance.LeaderboardEmpty += ShowNoGamesYet;

    }
    private void OnDisable()
    {
        if (MainMenuEvents.Instance == null) return;

        MainMenuEvents.Instance.LeaderboardEmpty -= ShowNoGamesYet;
    }

    private void ShowNoGamesYet()
    {
        noGamesYetObj.SetActive(true);
        leaderboards.SetActive(true);
    }

    public void ExitLeaderboard() 
    {
        gameObject.SetActive(false);
    }
}
