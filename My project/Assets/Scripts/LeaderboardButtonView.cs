using System;
using UnityEngine;

public class LeaderboardButtonView : MonoBehaviour 
{
    public Action LeaderBoardBUttonClicked;
    public void OnLeaderBoardClick() 
    {
        LeaderBoardBUttonClicked?.Invoke();
    }
}
