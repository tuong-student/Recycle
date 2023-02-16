using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NOOD
{
    public class MoveUpAndDisable : MonoBehaviour
    {
        private TextMeshPro textMeshPro;
        private float speed = 2f;

        private void Start()
        {
            textMeshPro = GetComponent<TextMeshPro>();
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

    public class DebugText
    {
        public static void Create(string text)
        {
            GameObject gameObject = new GameObject("TextMeshProGameObject");
            TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
            textMeshPro.text = text;
            textMeshPro.enableWordWrapping = false;
            gameObject.AddComponent<MoveUpAndDisable>();
        }

        public static void Create(string text, Vector3 position)
        {
            GameObject gameObject = new GameObject("TextMeshProGameObject");
            gameObject.transform.position = position;
            TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
            textMeshPro.text = text;
            textMeshPro.enableWordWrapping = false;
            gameObject.AddComponent<MoveUpAndDisable>();
        }

        public static void Create(string text, float fontSize)
        {
            GameObject gameObject = new GameObject("TextMeshProGameObject");
            TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
            textMeshPro.text = text;
            textMeshPro.fontSize = fontSize;
            textMeshPro.enableWordWrapping = false;
            gameObject.AddComponent<MoveUpAndDisable>();
        }

        public static void Create(string text, Vector3 position, float fontSize)
        {
            GameObject gameObject = new GameObject("TextMeshProGameObject");
            gameObject.transform.position = position;
            TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
            textMeshPro.text = text;
            textMeshPro.fontSize = fontSize;
            textMeshPro.enableWordWrapping = false;
            gameObject.AddComponent<MoveUpAndDisable>();
        }
    }
}
