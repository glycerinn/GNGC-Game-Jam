using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectMission : MonoBehaviour
{
    public Button Missionbutton;
    public Button Missionbutton2;
    public Button Missionbutton3;
    public Button Menubutton;
    public Button Creditsbutton;
    public GameObject creditsPanel;
    private bool isLoading = false;

    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void Start()
    {
        audioManager.playDesktopBGM();

        Missionbutton.interactable = true;
        Missionbutton2.interactable = PlayerPrefs.GetInt("Mission2Unlocked", 0) == 1;
        Missionbutton3.interactable = PlayerPrefs.GetInt("Mission3Unlocked", 0) == 1;
    }

    public void onMission()
    {
        if (isLoading)
        return;

        isLoading = true;

        PlayerPrefs.SetInt("Mission2Unlocked", 1);
        PlayerPrefs.Save();

        audioManager.playClickSFX();
        StartCoroutine(LoadNextLevel("Game Scene"));
    }

    public void onMission2()
    {
        if (isLoading)
        return;

        isLoading = true;
        PlayerPrefs.SetInt("Mission3Unlocked", 1);
        PlayerPrefs.Save();
        
        audioManager.playClickSFX();
        StartCoroutine(LoadNextLevel("Game Scene 2"));
    }

    public void onMission3()
    {
        if (isLoading)
        return;

        isLoading = true;
        audioManager.playClickSFX();
        StartCoroutine(LoadNextLevel("Game Scene 3"));
    }

    public void onMenu()
    {
        if (isLoading)
        return;

        isLoading = true;
        audioManager.playClickSFX();
        StartCoroutine(LoadNextLevel("Main Menu"));
    }

    public void onCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void onClose()
    {
        creditsPanel.SetActive(false);
    }

    IEnumerator LoadNextLevel(string level)
    {
        yield return StartCoroutine(Transition.Instance.PlayTransition());

        SceneManager.LoadScene(level);

        yield return StartCoroutine(Transition.Instance.EndTransition());
    }
}
