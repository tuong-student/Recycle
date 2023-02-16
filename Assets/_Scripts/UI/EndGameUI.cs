using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Game.Manager;

namespace Game.UI
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] private HighScoreSO highScoreSO;
        [SerializeField] private TextMeshProUGUI highScore;
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private Button mainMenuBtn;
        [SerializeField] private Button replayBtn;

        private void Start()
        {
            mainMenuBtn.onClick.AddListener(() =>
            {
                ResetStaticData.Instance.Dispose();
                Loader.LoadToScene(Loader.Scene.MainMenu);
            });
            replayBtn.onClick.AddListener(() =>
            {
                ResetStaticData.Instance.Dispose();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            });

            GameManager.OnGameOver += (object sender, System.EventArgs e) => Show();
            GameManager.OnPauseGame += (object sender, System.EventArgs e) => Show();
            GameManager.OnContinueGame += (object sender, System.EventArgs e) => Hide();
            Hide();
        }

        private void SetContent()
        {
            highScore.text = highScoreSO.highScore.ToString();
            score.text = ScoreManager.Instance.GetScore().ToString();
        }

        private void Show()
        {
            this.gameObject.SetActive(true);
            SetContent();
        }

        private void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}
