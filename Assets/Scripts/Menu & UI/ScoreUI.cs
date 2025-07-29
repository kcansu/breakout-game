using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;

    private void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        highScore.text = "High Score\n" + GameManager.Instance.highScore.ToString();
        
    }

    private void Update()
    {
        if(GameManager.Instance != null)
        {
            score.text = GameManager.Instance.Score.ToString();
        }
    }
}
