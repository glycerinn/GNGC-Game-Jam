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
    
    public void onTutor()
    {
        StartCoroutine(LoadNextLevel("Tutorial"));
    }

    public void onMission()
    {
        StartCoroutine(LoadNextLevel("Game Scene"));
    }

    public void onMenu()
    {
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
