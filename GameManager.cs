// Assets/Scripts/Core/GameManager.cs
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerState
{
    public string PlayerId;
    public List<Card> Hand = new List<Card>();
    public bool IsLocal;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Deck deck = new Deck();
    public List<Card> Discard = new List<Card>();
    public List<PlayerState> Players = new List<PlayerState>();
    public int CurrentPlayerIndex = 0;
    public int Direction = 1; // 1 = clockwise, -1 = anticlockwise

    void Awake() { Instance = this; }

    public void StartGame(List<string> playerIds)
    {
        Players.Clear();
        foreach (var id in playerIds) Players.Add(new PlayerState { PlayerId = id });
        deck.InitStandardUno();
        deck.Shuffle();
        DealInitialHands();
        Discard.Add(deck.Draw()); // start discard
        CurrentPlayerIndex = 0;
        Direction = 1;
    }

    void DealInitialHands()
    {
        for (int p = 0; p < Players.Count; p++)
        {
            Players[p].Hand.Clear();
        }
        for (int i = 0; i < 7; i++)
        {
            for (int p = 0; p < Players.Count; p++)
            {
                Players[p].Hand.Add(deck.Draw());
            }
        }
    }

    public bool CanPlay(Card c)
    {
        var top = Discard.Last();
        if (c.Value == CardValue.Wild || c.Value == CardValue.WildDrawFour) return true;
        if (c.Color == top.Color) return true;
        if (c.Value == top.Value) return true;
        return false;
    }

    public void PlayCard(string playerId, Card card)
    {
        var player = Players.FirstOrDefault(x => x.PlayerId == playerId);
        if (player == null) return;
        if (!player.Hand.Contains(card)) return;
        if (!CanPlay(card)) return;

        player.Hand.Remove(card);
        Discard.Add(card);
        ApplyCardEffect(card);
        NextTurn();
        // TODO: server validation and broadcasting
    }

    void ApplyCardEffect(Card c)
    {
        if (c.Value == CardValue.Reverse) Direction *= -1;
        if (c.Value == CardValue.Skip) CurrentPlayerIndex = (CurrentPlayerIndex + Direction + Players.Count) % Players.Count;
        if (c.Value == CardValue.DrawTwo) {
            int idx = (CurrentPlayerIndex + Direction + Players.Count) % Players.Count;
            Players[idx].Hand.Add(deck.Draw());
            Players[idx].Hand.Add(deck.Draw());
        }
        if (c.Value == CardValue.WildDrawFour) {
            int idx = (CurrentPlayerIndex + Direction + Players.Count) % Players.Count;
            Players[idx].Hand.Add(deck.Draw()); Players[idx].Hand.Add(deck.Draw()); Players[idx].Hand.Add(deck.Draw()); Players[idx].Hand.Add(deck.Draw());
        }
    }

    void NextTurn()
    {
        CurrentPlayerIndex = (CurrentPlayerIndex + Direction + Players.Count) % Players.Count;
    }
}
