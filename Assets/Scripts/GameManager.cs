using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //WE'LL MANAGE LIVES, LOSE AND WIN CONDITIONS AND SCORE HERE.

    public static GameManager Instance;

    public int lives {get; private set;} = 3;
    public int Score {get; private set;}
    public int highScore;

    public bool isGameOver {get; private set;} = false;

    public GameObject[] hearts;
    public GameOverMenu gameOverMenu;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ResetGame();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void AddScore(int scoreValue)
    {
        Score += scoreValue;
        //   Debug.Log("Current Score: " + Score);
        if (Score > highScore)
        {
            highScore = Score;
            PlayerPrefs.SetInt("HighScore", highScore); 
            PlayerPrefs.Save(); // opt but ensures
        }
    }

    public void LoseLife()
    {
        lives--;

        if (lives >= 0 && lives < hearts.Length)
        {
            hearts[lives].SetActive(false); 
        }
        if (lives <= 0)
        {
            isGameOver = true;
            gameOverMenu.TriggerGameOver();
        }
        

    }

    public void ResetGame()
    {
        lives = 3;
        Score = 0;
        isGameOver = false;
    }



}
