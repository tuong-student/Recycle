using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private TrashObjectUI trashObjectUI;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void SetObjectUI(TrashObjectUI trashObjectUI)
    {
        this.trashObjectUI = trashObjectUI;
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
}
