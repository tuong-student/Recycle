using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using NOOD;
using Game.Object;
using Game.SO;

namespace Game.Manager
{
    public class ScoreManager : AbstractMonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }
        public static EventHandler OnScoreAdded;

        [SerializeField] private HighScoreSO highScoreSO;

        public class OnScoreAddEventArgs : EventArgs
        {
            public int score;
        }

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Color showColor;

        private int score = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            this.AddTo(ResetStaticData.Instance);
        }

        private void Update()
        {
            if(scoreText.color.a > 0)
            {
                Color tempColor = scoreText.color;
                tempColor.a -= Time.deltaTime;
                scoreText.color = tempColor;
            }
        }

        public void AddScore()
        {
            score++;
            if (highScoreSO.highScore < score) highScoreSO.highScore = score;
            ShowAnimation();
            UpdateVisual();
            OnScoreAdded?.Invoke(this, new OnScoreAddEventArgs { score = this.score });
        }

        private void UpdateVisual()
        {
            ShowAnimation();
            scoreText.text = score.ToString();
        }

        private void ShowAnimation()
        {
            scoreText.color = showColor;
            scoreText.gameObject.transform.DOScale(0, 0f);
            scoreText.gameObject.transform.DOScale(3, 2f);
        }

        public float GetScore()
        {
            return score;
        }

        public override void Dispose()
        {
            Instance = null;
            OnScoreAdded = null;
        }
    }
}
