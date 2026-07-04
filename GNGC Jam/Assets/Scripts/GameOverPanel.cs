using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject GamePanel;
    public TextMeshProUGUI resultText;
    private bool isLoading = false;

    void Start()
    {
        GamePanel.SetActive(false);
    }

    public void ShowWin()
    {
        resultText.text = "YOU WIN!";
        GamePanel.SetActive(true);
    }

    public void ShowLose()
    {
        resultText.text = "YOU LOSE!";
        GamePanel.SetActive(true);
    }

    public void backtoMenu()
    {
        if (isLoading)
        return;

        isLoading = true;
        StartCoroutine(LoadNextLevel("Select Mission"));
    }

    IEnumerator LoadNextLevel(string level)
    {
        yield return StartCoroutine(Transition.Instance.PlayTransition());

        SceneManager.LoadScene(level);

        yield return StartCoroutine(Transition.Instance.EndTransition());
    }
}
