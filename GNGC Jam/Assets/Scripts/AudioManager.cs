using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource SFX;

    public AudioClip MainMenuBGM;
    public AudioClip GameBGM;
    public AudioClip BossBGM;
    public AudioClip GameOverBGM;
    public AudioClip DesktopBGM;
    public AudioClip DialogueBGM;
    public AudioClip clicksfx;
    public AudioClip hurtsfx;
    public AudioClip shootsfx;
    public AudioClip enemyshootsfx;
    public AudioClip enemydiesfx;
    public AudioClip missionSelectsfx;
    public AudioClip loginsfx;
    public AudioClip databasesfx;


    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void playMainMenuBGM()
    {
        BGM.clip = MainMenuBGM;
        BGM.Play();
    }

    public void playGameBGM()
    {
        BGM.clip = GameBGM;
        BGM.Play();
    }

    public void playBossBGM()
    {
        BGM.clip = BossBGM;
        BGM.Play();
    }

    public void playDialogueBGM()
    {
        BGM.clip = DialogueBGM;
        BGM.Play();
    }

    public void playDesktopBGM()
    {
        BGM.clip = DesktopBGM;
        BGM.Play();
    }

    public void playGameOverBGM()
    {
        BGM.clip = GameOverBGM;
        BGM.Play();
    }

    public void playClickSFX()
    {
        SFX.PlayOneShot(clicksfx);
    }

    public void playHurtSFX()
    {
        SFX.PlayOneShot(hurtsfx);
    }

    public void playShootSFX()
    {
        SFX.PlayOneShot(shootsfx);
    }

    public void playEnemyShootSFX()
    {
        SFX.PlayOneShot(enemyshootsfx);
    }

    public void playEnemyDieSFX()
    {
        SFX.PlayOneShot(enemydiesfx);
    }

    public void playMissionSelectSFX()
    {
        SFX.PlayOneShot(missionSelectsfx);
    }

    public void playLoginSFX()
    {
        SFX.PlayOneShot(loginsfx);
    }

    public void playDatabaseSFX()
    {
        SFX.PlayOneShot(databasesfx);
    }
}