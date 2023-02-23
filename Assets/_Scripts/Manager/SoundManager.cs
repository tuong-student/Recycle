using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.SO;
using Game.Object;
using Game.UI;
using NOOD;

namespace Game.Manager
{
    public class SoundManager : MonoBehaviorInstance<Manager.SoundManager>
    {

        [SerializeField] private SoundRefSO soundRefSO;
        private Vector3 cameraPos;

        public void InitInMainMenu()
        {
            cameraPos = Camera.main.transform.position;
            TrashCan.OnTrashCanHovered += TrashCan_OnTrashCanHovered;
            TrashCan.OnCorrectTrashObject += TrashCan_OnCorrectTrashObject;
            TrashCan.OnWrongTrashObject += TrashCan_OnWrongTrashObject;
            PlayerManager.OnPlayerPickup += PlayerManager_OnPlayerPickup;
            EndGameUI.OnClickEvent += EndGameUI_OnClickEvent;
            EndGameUI.OnHoverEvent += EndGameUI_OnHoverEvent;
            GameManager.OnPauseGame += GameManager_OnPauseGame;
            GameManager.OnContinueGame += GameManager_OnContinueGame;
        }

        public void InitInGameScene()
        {
            cameraPos = Camera.main.transform.position;
            MainMenuUI.OnButtonClick += MainMenuUI_OnButtonClick;
            MainMenuUI.OnHover += MainMenuUI_OnHover;
        }

        private void PlaySound(AudioClip[] audioClipArry, Vector3 position, float volume = 1f)
        {
            if(SoundSetting.GetInstance.IsSoundEnable())
                AudioSource.PlayClipAtPoint(audioClipArry[UnityEngine.Random.Range(0, audioClipArry.Length)], position, volume);
        }

        private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
        {
            if (SoundSetting.GetInstance.IsSoundEnable())
                AudioSource.PlayClipAtPoint(audioClip, position, volume);
        }

        private void TrashCan_OnTrashCanHovered(object sender, System.EventArgs eventArgs)
        {
            PlaySound(soundRefSO.hover, cameraPos, 0.1f);
        }

        private void TrashCan_OnCorrectTrashObject(object sender, System.EventArgs eventArgs)
        {
            PlaySound(soundRefSO.Correct, cameraPos, 0.1f);
            PlaySound(soundRefSO.TimeAdded, cameraPos, 0.1f);
        }

        private void TrashCan_OnWrongTrashObject(object sender, System.EventArgs eventArgs)
        {
            PlaySound(soundRefSO.Wrong, cameraPos, 0.1f);
        }

        private void PlayerManager_OnPlayerPickup(object sender, System.EventArgs eventArgs)
        {
            PlaySound(soundRefSO.PickUp, cameraPos, 0.01f);
        }

        private void MainMenuUI_OnButtonClick(object sender, MainMenuUI.OnButtonClickEventArgs eventArgs)
        {
            PlaySound(soundRefSO.buttonClick, cameraPos, 0.1f);
            NoodyCustomCode.StartDelayFunction(eventArgs.callBackAction, soundRefSO.buttonClick.length * ((Time.timeScale < 0.01f) ? 0.01f : Time.timeScale));
        }

        private void MainMenuUI_OnHover(object sender, System.EventArgs eventArgs)
        {
            PlaySound(soundRefSO.hover, cameraPos, 0.1f);
        }

        private void EndGameUI_OnClickEvent(object sender, EndGameUI.OnClickEventArgs eventArgs)
        {
            PlaySound(soundRefSO.buttonClick, cameraPos, 0.1f);
            NoodyCustomCode.StartDelayFunction(eventArgs.callBackAction, soundRefSO.buttonClick.length * ((Time.timeScale < 0.01f) ? 0.01f : Time.timeScale));
        }

        private void EndGameUI_OnHoverEvent(object sender, EventArgs eventArgs)
        {
            PlaySound(soundRefSO.hover, cameraPos, 0.1f);
        }

        private void GameManager_OnPauseGame(object sender, EventArgs eventArgs)
        {
            PlaySound(soundRefSO.pause, cameraPos, 0.1f);
        }

        private void GameManager_OnContinueGame(object sender, EventArgs eventArgs)
        {
            PlaySound(soundRefSO.pause, cameraPos, 0.1f);
        }
    }
}
