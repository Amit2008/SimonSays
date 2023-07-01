using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        leaderboardButtonView.LeaderBoardBUttonClicked += HandleLeaderboardButtonClick;
    }
    private void OnDisable()
    {
        if (leaderboardButtonView == null) return;
        leaderboardButtonView.LeaderBoardBUttonClicked -= HandleLeaderboardButtonClick;
    }

    private void HandleLeaderboardButtonClick() 
    {
        leaderboardScreenObj.SetActive(true);
    }
}
