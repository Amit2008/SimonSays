using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The LeaderboardButtonConroller class is responsible for controlling the leaderboard button behavior.
/// </summary>
[RequireComponent(typeof(LeaderboardButtonView))]
public class LeaderboardButtonConroller : MonoBehaviour
{
    private LeaderboardButtonView leaderboardButtonView;
    [SerializeField] private GameObject leaderboardScreenObj;

    private void Awake()
    {
        leaderboardButtonView = GetComponent<LeaderboardButtonView>();
    }

    private void OnEnable()
    {
        leaderboardButtonView.LeaderBoardButtonClicked += HandleLeaderboardButtonClick;
    }

    private void OnDisable()
    {
        if (leaderboardButtonView == null) return;
        leaderboardButtonView.LeaderBoardButtonClicked -= HandleLeaderboardButtonClick;
    }

    /// <summary>
    /// Handles the leaderboard button click by activating the leaderboard screen game object.
    /// </summary>
    private void HandleLeaderboardButtonClick()
    {
        leaderboardScreenObj.SetActive(true);
    }
}

