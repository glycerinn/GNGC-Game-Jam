using UnityEngine;
using Yarn.Unity;

public class LevelManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public EnemySpawner enemySpawner;
    public GameTimer gameTimer;
    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
        audioManager.playDialogueBGM();
        dialogueRunner.StartDialogue("GameDialogue");
    }

    
    void StartGame()
    {
        Debug.Log("Gameplay enabled!");
        enemySpawner.enabled = true;
        audioManager.playGameBGM();
        gameTimer.StartTimer();
    }
}