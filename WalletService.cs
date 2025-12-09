// Assets/Scripts/Services/WalletService.cs
using UnityEngine;

public class WalletService : MonoBehaviour
{
    public static WalletService Instance;
    public long Coins = 1000;
    public int Gems = 10;

    void Awake() { Instance = this; }

    public bool SpendCoins(long amount)
    {
        if (Coins < amount) return false;
        Coins -= amount;
        // sync to server
        return true;
    }

    public void AddCoins(long amount)
    {
        Coins += amount;
        // sync to server
    }
}
