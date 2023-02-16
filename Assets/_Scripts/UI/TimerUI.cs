using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Manager;

namespace Game.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Image timerImage;

        private void Update()
        {
            if(GameManager.Instance != null)
                timerImage.fillAmount = GameManager.Instance.gameTimer / GameManager.Instance.gameTimerMax;
        }
    }
}
