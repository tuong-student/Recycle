using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Manager;

namespace Game.UI
{
    public class SettingUI : MonoBehaviour
    {
        [SerializeField] private Sprite turnOnSound, turnOffSound, turnOnMusic, turnOffMusic;

        [SerializeField] private Image soundImage;
        [SerializeField] private Image musicImage;

        [SerializeField] private Button soundBtn, musicBtn;

        private void Awake()
        {
            soundBtn.onClick.AddListener(() =>
            {
                SoundSetting.GetInstance.PressSoundButton();
                UpdateSoundImage();
            });

            musicBtn.onClick.AddListener(() =>
            {
                SoundSetting.GetInstance.PressMusicButton();
                UpdateMusicImage();
            });
        }

        private void Start()
        {
            UpdateSoundImage();
            UpdateMusicImage();
        }

        private void UpdateSoundImage()
        {
            if(SoundSetting.GetInstance.IsSoundEnable())
            {
                soundImage.sprite = turnOnSound;
            }
            else
            {
                soundImage.sprite = turnOffSound;
            }
        }

        private void UpdateMusicImage()
        {
            if(SoundSetting.GetInstance.IsMusicEnable())
            {
                musicImage.sprite = turnOnMusic;
            }
            else
            {
                musicImage.sprite = turnOffMusic;
            }
        }
    }
}
