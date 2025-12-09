// Assets/Scripts/Matchmaking/TournamentManager.cs
using System;
using System.Collections.Generic;
using UnityEngine;

public class Tournament
{
    public string TournamentId;
    public string Title;
    public DateTime StartTime;
    public int BuyIn;
    public int MaxPlayers;
    public List<string> Participants = new List<string>();
    public string Status = "waiting";
}

public class TournamentManager : MonoBehaviour
{
    public static TournamentManager Instance;
    private Dictionary<string, Tournament> tournaments = new Dictionary<string, Tournament>();

    void Awake() { Instance = this; }

    public Tournament CreateTournament(string title, DateTime start, int buyIn, int maxPlayers)
    {
        var id = Guid.NewGuid().ToString();
        var t = new Tournament { TournamentId = id, Title = title, StartTime = start, BuyIn = buyIn, MaxPlayers = maxPlayers };
        tournaments[id] = t;
        Debug.Log("Tournament created: " + id);
        return t;
    }

    public void JoinTournament(string tournamentId, string playerId)
    {
        if (!tournaments.ContainsKey(tournamentId)) return;
        var t = tournaments[tournamentId];
        if (t.Participants.Contains(playerId)) return;
        t.Participants.Add(playerId);
        // notify server to lock in buy-in (server authoritative)
    }
}
