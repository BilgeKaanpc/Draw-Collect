using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private throwBall _ThrowBall;
    [SerializeField] private drawLine _DrawLine;
    [SerializeField] AudioSource basketSound, gameOverSound;
    [SerializeField] TMP_Text bestScoreText ,endBestText,scoreText;
    [SerializeField] ParticleSystem basketEffect, bestEffect;
    [SerializeField] GameObject playPanel, gameOverPanel, gamePanel;

    int score;
    void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
            endBestText.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
    }

    public void Continue(Vector2 pos)
    {
        score++;
        basketEffect.transform.position = pos;
        basketEffect.gameObject.SetActive(true);
        basketEffect.Play();
        basketSound.Play();
        _ThrowBall.Continue();
        _DrawLine.Continue();
    }
    public void PlayGame()
    {
        _ThrowBall.playGame();
        _DrawLine.startDrawing();
        playPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        gamePanel.SetActive(false);
        gameOverSound.Play();
        gameOverPanel.SetActive(true);
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestEffect.gameObject.SetActive(true);
            endBestText.text = PlayerPrefs.GetInt("BestScore").ToString();
            bestEffect.Play();
        }
        _ThrowBall.stopThrowing();
        _DrawLine.stopDrawing();
    }
}
