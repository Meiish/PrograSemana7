using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUi : MonoBehaviour
{
    private static ScoreUi instance;

    public static ScoreUi Instance {  get { return instance; } }

    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(int score)
    {
        scoreText.text= $"Score: {score}";
    }
}
