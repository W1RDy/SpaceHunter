using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneModel : MonoBehaviour
{
    [SerializeField] GameObject pauseWindow, loseWindow, winWindow;
    [SerializeField] ResultModel result;
    [SerializeField] public int countEnemy;
    [SerializeField] public Vector2 zoneSize;
    [SerializeField] public bool isHintChange = false;
    [SerializeField] public HintModel hint;
    public event Action GameOver;
    bool isPlaying = true;

    public void RestartScene() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void QuitGame() => Application.Quit();

    public void ContinueGame()
    {
        pauseWindow.SetActive(false);
        Time.timeScale = 1;
        if (isHintChange) hint.BreakAndChangeHint();
    }

    public void Pause()
    {
        if (isPlaying)
        {
            pauseWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void EndGame(bool isVictory)
    {
        isPlaying = false;
        var window = isVictory ? winWindow : loseWindow;
        if (isVictory) AudioManager.instance.PlaySound("Win");
        if (window) window.SetActive(true);
        result.OutputResult();
        GameOver();
    }
}
