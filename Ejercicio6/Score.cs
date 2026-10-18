using UnityEngine;

public class Score : MonoBehaviour
{
    public delegate void message(int score);
    public event message OnScoreUpgrade;
    private int score;
    void Start()
    {
        score = 0;   
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Tipo 1"))
        {
            score += 5;
            
        } else if (collider.gameObject.CompareTag("Tipo 2"))
        {
            score += 10;
        } 
        OnScoreUpgrade(score);
    }
}