using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int health = 3;
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

    public bool HasEnoughScore()
    {
        return score >= targetScore;
    }


    public void TakeDamage(int amount)
    {
        health -= amount;

        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            ResetGame();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");

        }
    }

    public void ResetGame()
    {
        score = 0;
        health = 3;
    }
}

