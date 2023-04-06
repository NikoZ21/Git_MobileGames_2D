using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DotRescue._Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _newBestText;
        [SerializeField] private TMP_Text _highScoreText;

        private void Awake()
        {
            if (GameManager.Instance.IsInitialized)
            {
            }
            else
            {
                _scoreText.gameObject.SetActive(false);
                _newBestText.gameObject.SetActive(false);
                _highScoreText.text = GameManager.Instance.HighScore.ToString();
            }
        }

        [SerializeField] private float _animationTime;
        [SerializeField] private AnimationCurve _speedCurve;


        private IEnumerator ShowScore()
        {
            int tempScore = 0;
            _scoreText.text = tempScore.ToString();

            int currentScore = GameManager.Instance.CurrentScore;
            int highScore = GameManager.Instance.HighScore;

            if (highScore < currentScore)
            {
                _newBestText.gameObject.SetActive(true);
                GameManager.Instance.HighScore = currentScore;
            }
            else
            {
                _newBestText.gameObject.SetActive(false);
            }

            _highScoreText.text = GameManager.Instance.HighScore.ToString();

            float speed = 1 / _animationTime;
            float timeElapsed = 0;

            while (timeElapsed < _animationTime)
            {
                timeElapsed += speed * Time.deltaTime;

                tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
                _scoreText.text = tempScore.ToString();
                yield return null;
            }

            tempScore = currentScore;
            _scoreText.text = tempScore.ToString();
        }

        [SerializeField] private AudioClip _clicClip;

        public void ClickedClip()
        {
            SoundManager.Instance.PlaySound(_clicClip);
            GameManager.Instance.GoToGamePlay();
        }
    }
}