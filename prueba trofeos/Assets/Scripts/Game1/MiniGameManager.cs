using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameJolt.API;

public class MiniGameManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform spawnArea;
    public float gameDuration = 10f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private int score = 0;
    private int requiredScoreForFirstTrophy = 1;
    private int requiredScoreForSecondTrophy = 15;
    private bool firstTrophyUnlocked = false;
    private bool secondTrophyUnlocked = false;

    private void Start()
    {
        scoreText.text = $"Score: {score}";
        timerText.text = $"{gameDuration}";
        StartCoroutine(StartMiniGame());
    }

    private IEnumerator StartMiniGame()
    {
        float timeLeft = gameDuration;

        while (timeLeft > 0)
        {
            SpawnButton();
            timeLeft -= 0.2f;
            timerText.text = $"{Mathf.Ceil(timeLeft)}";
            yield return new WaitForSeconds(0.2f);
        }

        EndMiniGame();
    }

    private void SpawnButton()
    {
        RectTransform rectTransform = spawnArea.GetComponent<RectTransform>();
        Vector2 size = rectTransform.rect.size;

        
        float spawnFactor = 8f;

        
        Vector2 spawnPosition = new Vector2(
            Random.Range(-size.x / 2 * spawnFactor, size.x / 2 * spawnFactor),
            Random.Range(-size.y / 2 * spawnFactor, size.y / 2 * spawnFactor)
        );

        
        GameObject button = Instantiate(buttonPrefab, spawnArea);
        button.transform.localPosition = spawnPosition;
        button.transform.localScale = Vector3.one;

        
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(() => ButtonClicked(button));
    }

    private void ButtonClicked(GameObject button)
    {
        score++;
        scoreText.text = $"Score: {score}";
        Destroy(button);

        
        if (score >= requiredScoreForFirstTrophy && !firstTrophyUnlocked)
        {
            Trophies.Unlock(248814);
            firstTrophyUnlocked = true;
            Debug.Log("¡Primer trofeo desbloqueado!");
        }

        
        if (score >= requiredScoreForSecondTrophy && !secondTrophyUnlocked)
        {
            Trophies.Unlock(248856);
            secondTrophyUnlocked = true;
            Debug.Log("¡Segundo trofeo desbloqueado!");
        }
    }

    private void EndMiniGame()
    {
        Debug.Log($"juego terminado! Puntuación final: {score}");
        SceneManager.LoadScene("GameOver2");
    }
}