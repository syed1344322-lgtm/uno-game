// Assets/Scripts/Core/Card.cs
using System;

public enum CardColor { Red, Yellow, Green, Blue, Wild }
public enum CardValue { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Skip, Reverse, DrawTwo, Wild, WildDrawFour }

[Serializable]
public class Card
{
    public CardColor Color;
    public CardValue Value;

    public Card(CardColor color, CardValue value)
    {
        Color = color;
        Value = value;
    }

    public override string ToString() => $"{Color} {Value}";
}
