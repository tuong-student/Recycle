using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game.Manager
{
    public class GameManager : AbstractMonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public static EventHandler OnGameOver;
        public static EventHandler OnPauseGame;
        public static EventHandler OnContinueGame;
        private bool isGameOnver = false;
        private bool isPauseGame = false;

        public float gameTimer;
        public float gameTimerMax = 30f;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            this.AddTo(ResetStaticData.Instance);
            gameTimer = gameTimerMax;
            isGameOnver = true;
            ScoreManager.OnScoreAdded += ScoreManager_OnScoreAdded;
        }

        private void Update()
        {
            gameTimer -= Time.deltaTime;
            if(gameTimer <= 0)
            {
                gameTimer = gameTimerMax;

                GameOver();
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }

        private void PauseGame()
        {
            isPauseGame = !isPauseGame;
            if (isPauseGame)
            {
                OnPauseGame?.Invoke(this, EventArgs.Empty);
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
                OnContinueGame?.Invoke(this, EventArgs.Empty);
            }
        }

        private void GameOver()
        {
            Time.timeScale = 0f;
            OnGameOver?.Invoke(this, EventArgs.Empty);
            isGameOnver = true;
        }

        private void ScoreManager_OnScoreAdded(object sender, System.EventArgs e)
        {
            gameTimer += 0.5f;
        }

        public override void Dispose()
        {
            Instance = null;
            OnGameOver = null;
            OnPauseGame = null;
            OnContinueGame = null;
        }
    }
}
