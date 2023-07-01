using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardScreen : MonoBehaviour
{
    [SerializeField] private GameObject leaderboards;
    [SerializeField] private GameObject noGamesYetObj;

    public void ShowNoGamesYet()
    {
        noGamesYetObj.SetActive(true);
        leaderboards.SetActive(true);
    }

    public void ExitLeaderboard() 
    {
        gameObject.SetActive(false);
    }
}
