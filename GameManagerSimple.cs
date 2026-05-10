using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerSimple : MonoBehaviour
{
    public static GameManagerSimple Instance;

    public TextMeshProUGUI statusText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private bool isGameOver = false;

    // Enemy tracking
    private int enemiesRemaining = 0;

    // Score system
    private int score = 0;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;

        enemiesRemaining = 0; 
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
    
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Win();
        }
    }
        
    // HEALTH UI
    public void SetHealth(int current, int max)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + current + " / " + max;
        }
    }

    // ENEMY SYSTEM
    public void RegisterEnemy()
    {
        enemiesRemaining++;
        Debug.Log("Enemy registered: " + enemiesRemaining);
    }

    public void EnemyKilled()
    {
        enemiesRemaining--;

        Debug.Log("Enemy killed. Remaining: " + enemiesRemaining);

        if (enemiesRemaining <= 0)
        {
            enemiesRemaining = 0; 

            if (!isGameOver)
            {
                Win();
            }
        }
    }

    // SCORE SYSTEM
    public void AddScore(int amount)
    {
        score += amount;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // LOSE GAME
    public void Lose()
    {
        isGameOver = true;

        if (statusText != null)
        {
            statusText.gameObject.SetActive(true);
            statusText.text = "GAME OVER\nPress R to Restart";
        }

        Time.timeScale = 0f;
    }

    // WIN GAME
    public void Win()
    {
        isGameOver = true;

        Debug.Log("WIN TRIGGERED"); 

        if (statusText != null)
        {
            statusText.gameObject.SetActive(true);
            statusText.text = "YOU WIN!\nPress R to Restart";
        }

        Time.timeScale = 0f;
    }

    // RESTART GAME
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}