using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DotRescue._Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InIt();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public bool IsInitialized { get; set; }

        public int CurrentScore { get; set; }

        private string highScoreKey = "HighScore";

        public int HighScore
        {
            get { return PlayerPrefs.GetInt(highScoreKey); }
            set { PlayerPrefs.SetInt(highScoreKey, value); }
        }

        private void InIt()
        {
            CurrentScore = 0;
            IsInitialized = false;
        }

        private const string MainMenu = "MainMenu";
        private const string GamePlay = "GamePlay";

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(MainMenu);
        }

        public void GoToGamePlay()
        {
            SceneManager.LoadScene(GamePlay);
        }
    }
}