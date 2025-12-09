// Assets/Scripts/Services/PlayFabService.cs
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayFabService : MonoBehaviour
{
    public static PlayFabService Instance;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public void LoginAnonymously()
    {
        var req = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(req, OnLoginSuccess, OnLoginError);
    }

    void OnLoginSuccess(LoginResult r) => Debug.Log("PlayFab logged in: " + r.PlayFabId);
    void OnLoginError(PlayFabError err) => Debug.LogError("PlayFab login error: " + err.GenerateErrorReport());

    public void UpdateLeaderboard(int score)
    {
        var req = new UpdatePlayerStatisticsRequest
        {
            Statistics = new System.Collections.Generic.List<StatisticUpdate>
            {
                new StatisticUpdate{ StatisticName = "GlobalRank", Value = score }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(req, res => Debug.Log("Leaderboard updated"), err => Debug.LogError(err.GenerateErrorReport()));
    }
}
