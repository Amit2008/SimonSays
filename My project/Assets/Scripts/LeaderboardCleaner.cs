using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardCleaner : MonoBehaviour
{
    private void OnDisable()
    {
        ClearLeaderboardList();
    }

    private void ClearLeaderboardList() 
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
