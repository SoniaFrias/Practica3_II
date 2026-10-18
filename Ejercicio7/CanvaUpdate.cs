using TMPro;
using UnityEngine;

public class CanvaUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI rewardText;
    public Score notifier;
    private int countFrames;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notifier.OnScoreUpgrade += upgrade;
        notifier.OnReward += reward;

        scoreText.text = "Puntuación 0";
        rewardText.enabled = false;
        rewardText.text = "¡Recompensa obtenida!";
    }

    void Update()
    {
        countFrames++;
        if (rewardText.enabled && countFrames > 240)
        {
            rewardText.enabled = false;
        }
    }

    void upgrade(int score)
    {
        scoreText.text = $"Puntuación {score}";
    }

    void reward()
    {
        countFrames = 0;
        rewardText.enabled = true;
    }
}