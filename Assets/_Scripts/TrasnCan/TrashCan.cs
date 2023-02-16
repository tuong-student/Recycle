using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Game.Manager;

namespace Game.Object
{
    public enum TrashType
    {
        Plastic,
        Metal,
        Glass,
        Organic
    }

    public class TrashCan : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        [SerializeField] private TrashType[] acceptType;

        [SerializeField] private TrashCanVisual trashCanVisual;


        public void OnPointerEnter(PointerEventData eventData)
        {
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
                    PlayerManager.Instance.GetTrashObjectUI().DestroySelf();
                    ScoreManager.Instance.AddScore();
                    trashCanVisual.CreateTimeText();
                }
            }
        }

        public bool IsAcceptable(TrashObjectUI trashObjectUI)
        {
            foreach(TrashType trashType in acceptType)
            {
                if (trashType == trashObjectUI.trashType) return true;
            }
            return false;
        }
    }
}
