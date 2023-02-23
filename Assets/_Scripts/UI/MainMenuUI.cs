using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics.Tracing;
using NOOD;
using Game.Manager;

namespace Game.UI
{
    public class MainMenuUI : MonoBehaviour, IDisposable
    {
        public static EventHandler<OnButtonClickEventArgs> OnButtonClick;
        public static EventHandler OnHover;

        public class OnButtonClickEventArgs : EventArgs
        {
            public Action callBackAction;
        }

        [SerializeField] private Button playBtn;
        [SerializeField] private Button exitBtn;

        private void Awake()
        {
            playBtn.onClick.AddListener(() =>
            {
                OnButtonClick?.Invoke(this, new OnButtonClickEventArgs
                {
                    callBackAction = () => Loader.LoadToScene(Loader.Scene.GameScene)
                });
            });
            exitBtn.onClick.AddListener(() =>
            {
                OnButtonClick?.Invoke(this, new OnButtonClickEventArgs
                {
                    callBackAction = () => Application.Quit()
                });
            });
        }

        private void Start()
        {
            SoundManager.GetInstance.InitInMainMenu();
        }

        public void PerformOnHoverEvent()
        {
            OnHover?.Invoke(this, EventArgs.Empty);
        }
        
        public void Dispose()
        {
            OnButtonClick = null;
            OnHover = null;
        }
    }
}
