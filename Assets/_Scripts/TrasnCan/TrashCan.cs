using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Game.Manager;
using NOOD;

namespace Game.Object
{
    public enum TrashType
    {
        Plastic,
        Metal,
        Glass,
        Organic
    }

    public class TrashCan : AbstractMonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        public static EventHandler OnTrashCanHovered;
        public static EventHandler OnCorrectTrashObject;
        public static EventHandler OnWrongTrashObject;

        private NOOD.NoodCamera.CameraShake cameraShake;

        [SerializeField] private TrashType[] acceptType;

        [SerializeField] private TrashCanVisual trashCanVisual;

        private void Start()
        {
            this.AddTo(ResetStaticData.Instance);
            cameraShake = this.GetComponent<NOOD.NoodCamera.CameraShake>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnTrashCanHovered?.Invoke(this, EventArgs.Empty);
            trashCanVisual.Open();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            trashCanVisual.Close();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (PlayerManager.Instance.IsHoldingTrash())
            {
                if(IsAcceptable(PlayerManager.Instance.GetTrashObjectUI()))
                {
                    ScoreManager.Instance.AddScore();
                    trashCanVisual.CreateTimeText();
                    OnCorrectTrashObject?.Invoke(this, EventArgs.Empty);
                    PlayerManager.Instance.GetTrashObjectUI().DestroySelf();
                }
                else
                {
                    OnWrongTrashObject?.Invoke(this, EventArgs.Empty);
                    Shake();
                }
            }
        }

        private void Shake()
        {
            cameraShake.Shake(0.2f, 20f);
        }

        public bool IsAcceptable(TrashObjectUI trashObjectUI)
        {
            foreach(TrashType trashType in acceptType)
            {
                if (trashType == trashObjectUI.trashType) return true;
            }
            return false;
        }

        public override void Dispose()
        {
            OnTrashCanHovered = null;
            OnCorrectTrashObject = null;
            OnWrongTrashObject = null;
        }
    }
}
