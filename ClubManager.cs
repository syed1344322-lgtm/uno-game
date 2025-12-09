// Assets/Scripts/Social/ClubManager.cs
using System.Collections.Generic;
using UnityEngine;

public class Club
{
    public string ClubId;
    public string Name;
    public string OwnerId;
    public List<string> Members = new List<string>();
    public long Bank;
}

public class ClubManager : MonoBehaviour
{
    public static ClubManager Instance;
    private Dictionary<string, Club> clubs = new Dictionary<string, Club>();

    void Awake() { Instance = this; }

    public void CreateClub(string name, string owner)
    {
        var id = System.Guid.NewGuid().ToString();
        var club = new Club { ClubId = id, Name = name, OwnerId = owner, Members = new List<string> { owner }, Bank = 0 };
        clubs[id] = club;
        Debug.Log("Club created: " + id);
        // persist to server (PlayFab CloudScript or your API)
    }

    public Club GetClub(string clubId) => clubs.ContainsKey(clubId) ? clubs[clubId] : null;
}
