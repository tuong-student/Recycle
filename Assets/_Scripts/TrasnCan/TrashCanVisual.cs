using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCanVisual : MonoBehaviour
{
    private Image image;
    [SerializeField] private Sprite closeImage, openImage;
    [SerializeField] private Outline outline;

    private void Awake()
    {
        image = GetComponent<Image>();
        outline.enabled = false;
    }

    public void Open()
    {
        outline.enabled = true;
        image.sprite = openImage;
    }

    public void Close()
    {
        outline.enabled = false;
        image.sprite = closeImage;
    }
}
