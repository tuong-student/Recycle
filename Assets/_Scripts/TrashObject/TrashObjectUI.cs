using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Manager;

namespace Game.Object
{
    public class TrashObjectUI : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Canvas canvas;
        private Rigidbody2D myBody;
        private CanvasGroup canvasGroup;
        private bool isHolding = false;
        private RectTransform rectTransform;
    

        [SerializeField] private TrashType _trashType;
        public TrashType trashType { get { return _trashType; } }

        private void Awake()
        {
            canvas = GetComponentInParent<Canvas>();
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            myBody = GetComponent <Rigidbody2D>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isHolding = true;
            myBody.bodyType = RigidbodyType2D.Kinematic;
            myBody.velocity = Vector3.zero;
            PlayerManager.Instance.SetObjectUI(this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isHolding = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {

        }

        public void OnPointerExit(PointerEventData eventData)
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            PlayerManager.Instance.ClearTrashObjectUI();
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void DestroySelf()
        {
            PlayerManager.Instance.ClearTrashObjectUI();
            Destroy(this.gameObject);
        }
    }
}
