using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI playerScoreText;

    public void SetLeaderBoardEntryView(string playerName, string playerScore) 
    {
        playerNameText.text = playerName;
        playerScoreText.text = playerScore;
    }
}
