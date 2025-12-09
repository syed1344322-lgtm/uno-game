// Assets/Scripts/Services/LeaderboardService.cs
using UnityEngine;
using System.Collections.Generic;

public class LeaderboardService : MonoBehaviour
{
    public static LeaderboardService Instance;

    void Awake() { Instance = this; }

    // local cache example
    public List<(string playerId, int score)> TopPlayers = new List<(string, int)>();

    public void RefreshGlobalTop()
    {
        // fetch from PlayFab or server
        Debug.Log("Refreshing global leaderboard (placeholder).");
    }
}
