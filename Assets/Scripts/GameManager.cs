using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int targetScore = 4;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void ResetGame()
    {
        score = 0;
    }
}

