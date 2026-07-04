using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene")]
    public int nextSceneIndex = 1;
    private bool isLoading = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            QuitGame();
            return;
        }

        if (Input.anyKeyDown)
        {
            if (isLoading)
            return;

            isLoading = true;
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return StartCoroutine(Transition.Instance.PlayTransition());

        SceneManager.LoadScene(nextSceneIndex);

        yield return StartCoroutine(Transition.Instance.EndTransition());
    }

    void QuitGame()
    {
        Debug.Log("Quitting Game...");

        Application.Quit();
    }
}