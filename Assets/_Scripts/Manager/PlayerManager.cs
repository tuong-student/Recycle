using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Object;
using NOOD;

namespace Game.Manager
{
    public class PlayerManager : AbstractMonoBehaviour
    {
        public static PlayerManager Instance { get; private set; }
        public static EventHandler OnPlayerPickup;

        [SerializeField] private TrashObjectUI trashObjectUI;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        private void Start()
        {
            this.AddTo(ResetStaticData.Instance);
        }

        public void SetObjectUI(TrashObjectUI trashObjectUI)
        {
            this.trashObjectUI = trashObjectUI;
            if (trashObjectUI != null)
                OnPlayerPickup?.Invoke(this, EventArgs.Empty);
        }

        public TrashObjectUI GetTrashObjectUI()
        {
            return trashObjectUI;
        }

        public void ClearTrashObjectUI()
        {
            trashObjectUI = null;
        }

        public bool IsHoldingTrash()
        {
            return trashObjectUI != null;
        }

        public override void Dispose()
        {
            OnPlayerPickup = null;
        }
    }
}
