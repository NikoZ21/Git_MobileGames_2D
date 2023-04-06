using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Player = DotRescue._Scripts.Player;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Player player;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        Time.timeScale = 1;
        playButton.SetActive(false);
        gameOver.SetActive(false);
        player.enabled = true;
        player.transform.position = Vector3.zero;
        PipesMovement[] pipes = FindObjectsOfType<PipesMovement>();
        foreach (var pipe in pipes)
        {
            pipe.transform.position = pipe.GetStartPosition();
            pipe.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        Pause();
        playButton.SetActive(true);
        gameOver.SetActive(true);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}