using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void TriggerGameOver()
    {
        gameOverPanel.SetActive(true);
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score\n" + savedHighScore;
        int currentScore = GameManager.Instance.Score;
        scoreText.text = "Score\n" + currentScore;
        Time.timeScale = 0; 

    }

    public void OnRetryClicked()
    {
        Debug.Log("Retry button pressed");
        Time.timeScale = 1f; //resume time before reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  
    }
    public void QuitGame()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}
