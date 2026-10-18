using TMPro;
using UnityEngine;

public class CanvaUpdate : MonoBehaviour
{
    private TextMeshProUGUI text;
    public Score notifier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        notifier.OnScoreUpgrade += upgrade;
        text.text = "Puntuación 0";
    }

    void upgrade(int score)
    {
        text.text = $"Puntuación {score}";
    }
}
