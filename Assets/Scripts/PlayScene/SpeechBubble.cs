using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

namespace BingsuTycoon.PlayScene
{
    public class SpeechBubble : MonoBehaviour
    {
        private TMP_Text textComponent;

        private float printInterval = 0.05f;
        private string content;
        private Coroutine printCoroutine;

        private void Awake()
        {
            textComponent = transform.Find("Text").GetComponent<TMP_Text>();
        }

        public void Print(string content)
        {
            this.content = content;
            printCoroutine = StartCoroutine(PrintCoroutine());
        }

        public void StopPrintCoroutine()
        {
            StopCoroutine(printCoroutine);
            textComponent.text = content;
        }

        public IEnumerator PrintCoroutine()
        {
            StringBuilder currentContent = new StringBuilder("");

            foreach (char item in content)
            {
                currentContent.Append(item);
                textComponent.text = currentContent.ToString();
                yield return new WaitForSeconds(printInterval);
            }
        }
    }
}