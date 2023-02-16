using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Object
{
    public class TrashCanVisual : MonoBehaviour
    {
        private Image image;
        private TrashCan trashCan;
        [SerializeField] private Sprite closeImage, openImage;
        [SerializeField] private Outline outline;
        [SerializeField] private Transform textPos;
        [SerializeField] private Transform trashText;

        private void Awake()
        {
            trashCan = GetComponentInParent<TrashCan>();
            image = GetComponent<Image>();
            outline.enabled = false;
        }

        private void Start()
        {

        }

        public void CreateTimeText()
        {
            Instantiate(trashText, textPos);
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
}
