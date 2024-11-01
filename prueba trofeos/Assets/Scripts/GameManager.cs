using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameJolt.API;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private float timer;
    private int score;

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }
    public void UpdateScore(int newScore)
    {
        score = newScore; // Actualiza el score con la cantidad de clics
        ScoreUi.Instance.UpdateScore(score); // Actualiza el UI
    }

    public void GameOver()
    {
        //SceneManager.LoadScene("GameOver");

        Scores.Add(score, $"Score: {score}", 941595, "", OnCallback);
    }

    private void OnCallback(bool success)
    {
        SceneManager.LoadScene("GameOver");
    }
}
