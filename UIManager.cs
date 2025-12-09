// Assets/Scripts/UI/UIManager.cs
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    void Awake() { Instance = this; }

    public void ShowPopup(string title, string body)
    {
        Debug.Log($"POPUP: {title} - {body}");
    }
}
