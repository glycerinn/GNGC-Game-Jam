using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectMission : MonoBehaviour
{
    public Button Tutorialbutton;
    public Button Missionbutton;
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
    }

    public void onTutor()
    {
        if (isLoading)
        return;

        isLoading = true;
        audioManager.playClickSFX();
        StartCoroutine(LoadNextLevel("Tutorial"));
    }

    public void onMission()
    {
        if (isLoading)
        return;

        isLoading = true;
        audioManager.playClickSFX();
        StartCoroutine(LoadNextLevel("Game Scene"));
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
