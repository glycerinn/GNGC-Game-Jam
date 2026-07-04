using UnityEngine;
using Yarn.Unity;

public class LevelManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public EnemySpawner enemySpawner;
    public GameTimer gameTimer;

    void Awake()
    {
        dialogueRunner.AddCommandHandler("StartGame", () =>
        {
            Debug.Log("StartGame command called!");
            StartGame();
        });

        Debug.Log("Registered StartGame");
    }

    void Start()
    {
        enemySpawner.enabled = false;
        dialogueRunner.StartDialogue("GameDialogue");
    }

    
    void StartGame()
    {
        Debug.Log("Gameplay enabled!");
        enemySpawner.enabled = true;
        gameTimer.StartTimer();
    }
}