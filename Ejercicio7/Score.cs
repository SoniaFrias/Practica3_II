using UnityEngine;

public class Score : MonoBehaviour
{
    public delegate void message(int score);
    public delegate void message2();
    public event message OnScoreUpgrade;
    public event message2 OnReward;
    private int score;
    private int reward;
    void Start()
    {
        score = 0;  
        reward = 0; 
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Tipo 1"))
        {
            score += 5;
            reward += 5;
            
        } else if (collider.gameObject.CompareTag("Tipo 2"))
        {
            score += 10;
            reward += 10;
        } 
        OnScoreUpgrade(score);
        if (reward >= 100)
        {
            reward -= 100;
            OnReward();
        }
    }
}
