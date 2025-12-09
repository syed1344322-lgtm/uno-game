// Assets/Scripts/Core/Deck.cs
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Card> cards = new List<Card>();

    public void InitStandardUno()
    {
        cards.Clear();
        // For each color (except Wild), add one 0, two of 1-9 & actions
        CardColor[] colors = new[] { CardColor.Red, CardColor.Yellow, CardColor.Green, CardColor.Blue };
        foreach (var c in colors)
        {
            cards.Add(new Card(c, CardValue.Zero));
            for (int i = 0; i < 2; i++)
            {
                cards.Add(new Card(c, CardValue.One));
                cards.Add(new Card(c, CardValue.Two));
                cards.Add(new Card(c, CardValue.Three));
                cards.Add(new Card(c, CardValue.Four));
                cards.Add(new Card(c, CardValue.Five));
                cards.Add(new Card(c, CardValue.Six));
                cards.Add(new Card(c, CardValue.Seven));
                cards.Add(new Card(c, CardValue.Eight));
                cards.Add(new Card(c, CardValue.Nine));
                cards.Add(new Card(c, CardValue.Skip));
                cards.Add(new Card(c, CardValue.Reverse));
                cards.Add(new Card(c, CardValue.DrawTwo));
            }
        }
        // Wilds
        for (int i = 0; i < 4; i++) cards.Add(new Card(CardColor.Wild, CardValue.Wild));
        for (int i = 0; i < 4; i++) cards.Add(new Card(CardColor.Wild, CardValue.WildDrawFour));
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int r = Random.Range(i, cards.Count);
            var tmp = cards[i];
            cards[i] = cards[r];
            cards[r] = tmp;
        }
    }

    public Card Draw()
    {
        if (cards.Count == 0) return null;
        var c = cards[0];
        cards.RemoveAt(0);
        return c;
    }

    public int Count => cards.Count;
}
