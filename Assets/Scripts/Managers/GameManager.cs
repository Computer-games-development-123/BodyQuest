using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum GameState { Playing, Win, GameOver }

    [Header("References")]
    [SerializeField] PlayerStats playerStats;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject gameOverPanel;

    [Header("Gameplay Settings")]
    [SerializeField] float levelDuration = 60f; // שניות לשרוד

    float remainingTime;
    GameState currentState = GameState.Playing;

    void Start()
    {
        if (playerStats == null)
        {
            playerStats = FindFirstObjectByType<PlayerStats>();
        }

        remainingTime = levelDuration;

        // לוודא שפאנלים מכובים בהתחלה
        if (winPanel != null) winPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (currentState != GameState.Playing)
            return;

        // טיימר – שורדים עד הסוף → ניצחון
        remainingTime -= Time.deltaTime;
        if (remainingTime < 0f)
        {
            remainingTime = 0f;
            Win();
        }

        UpdateTimerUI();

        // בדיקת חיים
        if (playerStats != null && playerStats.IsDead())
        {
            GameOver();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText == null) return;

        int seconds = Mathf.CeilToInt(remainingTime);
        timerText.text = $"Time: {seconds}";
    }

    void Win()
    {
        currentState = GameState.Win;
        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f; // עצירת המשחק
    }

    void GameOver()
    {
        currentState = GameState.GameOver;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // ניתן לקרוא מכפתורים ב-UI
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
