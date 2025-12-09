// Assets/Scripts/Matchmaking/MatchmakerClient.cs
using UnityEngine;
using System;
using System.Collections.Generic;

public class MatchmakerClient : MonoBehaviour
{
    public void FindRankedMatch()
    {
        // Example flow: request server to find opponent, server returns room token -> join Photon room
        Debug.Log("Requesting ranked match (placeholder).");
    }

    public void CreatePrivateMatch(string code)
    {
        // Create room with code, share with friends
        Debug.Log("CreatePrivateMatch: " + code);
    }
}
