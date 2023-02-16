using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Game.Object
{
    public class TrashObject : MonoBehaviour
    {
        private bool isHolding = false;
        private Vector3 mouseOldPos;

        private void OnMouseDown()
        {
            mouseOldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isHolding = true;
        }

        private void OnMouseUp()
        {
            Debug.Log("Up");
            isHolding = false;
        }

        private void OnMouseDrag()
        {
            Vector3 mouseNewPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mouseOffset = mouseNewPos - mouseOldPos;

            if (isHolding == true)
            {
                this.transform.position += mouseOffset;
            }
            mouseOldPos = mouseNewPos;
        }

        private void OnMouseEnter()
        {
        
        }

        private void OnMouseExit()
        {
        
        }

    }
}
