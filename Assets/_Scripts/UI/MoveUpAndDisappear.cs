using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class MoveUpAndDisappear : MonoBehaviour
    {
        private TextMeshProUGUI textMeshPro;
        private float speed = 20f;

        private void Start()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            Vector3 pos = this.gameObject.transform.position;
            pos.y += Time.deltaTime * speed;
            this.gameObject.transform.position = pos;

            if (textMeshPro.color.a > 0)
            {
                Color color = textMeshPro.color;
                color.a -= Time.deltaTime;
                textMeshPro.color = color;
            }
            if (textMeshPro.color.a <= 0)
                Destroy(textMeshPro.gameObject);
        }
    }
}
