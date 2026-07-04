using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameOverPanel winPanel;
    public EnemySpawner enemySpawner;
    public BulletShoot bulletShoot;
    public Shield shieldController;

    public float startingTime = 120f; // 2 minutes

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        timeRemaining = startingTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (!timerRunning)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            UpdateTimerText();

            timerRunning = false;
            MissionComplete();
            return;
        }

        UpdateTimerText();
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void MissionComplete()
    {
        bulletShoot.enabled = false;
        shieldController.enabled = false;
        enemySpawner.enabled = false;

        winPanel.ShowWin();

        Time.timeScale = 0f;
    }
}