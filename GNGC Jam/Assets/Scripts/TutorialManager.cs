using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class TutorialManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string nextScene = "Select Mission";
    private bool isLoading = false;

    void Awake()
    {
        dialogueRunner.AddCommandHandler("BacktoMission", () =>
        {
            Debug.Log("Command called!");
            StartCoroutine(ReturnCoroutine());
        });

        Debug.Log("Command registered");
    }

    void Start()
    {
        dialogueRunner.StartDialogue("Tutorial");
    }

    public void BacktoMissions()
    {
        Debug.Log("hi");
        StartCoroutine(ReturnCoroutine());
    }

    private IEnumerator ReturnCoroutine()
    {
        if (isLoading)
        yield break;

        isLoading = true;
        yield return StartCoroutine(Transition.Instance.PlayTransition());

        SceneManager.LoadScene(nextScene);

        yield return StartCoroutine(Transition.Instance.EndTransition());
    }
}