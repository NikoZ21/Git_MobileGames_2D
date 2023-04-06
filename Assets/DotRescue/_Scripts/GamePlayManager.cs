using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DotRescue._Scripts
{
    public class GamePlayManager : MonoBehaviour
    {
        private bool hasGameFinished;

        [SerializeField] private TMP_Text _scoreText;

        private float score;
        private float scoreSpeed;
        private int currentLevel;

        [SerializeField] private List<int> _levelSpeed, _levelMax;

        private void Awake()
        {
            GameManager.Instance.IsInitialized = true;

            hasGameFinished = false;
            score = 0;
            currentLevel = 0;
            _scoreText.text = ((int)score).ToString();

            scoreSpeed = _levelSpeed[currentLevel];
        }

        private void Update()
        {
            if (hasGameFinished) return;

            score += scoreSpeed * Time.deltaTime;
            _scoreText.text = ((int)score).ToString();

            if (score > _levelMax[Mathf.Clamp(currentLevel, 0, _levelSpeed.Count - 1)])
            {
                currentLevel = Mathf.Clamp(currentLevel + 1, 0, _levelSpeed.Count - 1);
                scoreSpeed = _levelSpeed[currentLevel];
            }
        }

        public void GameEnded()
        {
            hasGameFinished = true;
            GameManager.Instance.CurrentScore = (int)score;
            StartCoroutine(GameOver());
        }

        private IEnumerator GameOver()
        {
            yield return new WaitForSeconds(2f);
            GameManager.Instance.GoToMainMenu();
        }
    }
}