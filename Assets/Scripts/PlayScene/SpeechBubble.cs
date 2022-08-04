using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BingsuTycoon.PlayScene
{
    public class SpeechBubble : MonoBehaviour
    {
        private Button buttonComponent;
        private TMP_Text textComponent;

        private Button submitButtonComponent;
        private Button hintButtonComponent;

        private float printInterval = 0.05f;
        private string[] contents;
        private int contentIndex = 0;
        private Coroutine printCoroutine;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            textComponent = transform.Find("Text").GetComponent<TMP_Text>();
            submitButtonComponent = transform.Find("SubmitButton").GetComponent<Button>();
            hintButtonComponent = transform.Find("HintButton").GetComponent<Button>();

            buttonComponent.onClick.AddListener(OnClickButton);
            submitButtonComponent.onClick.AddListener(OnClickSubmitButton);
            hintButtonComponent.onClick.AddListener(OnClickHintButton);

            SetOptionsActive(false);
        }

        private void SetOptionsActive(bool value)
        {
            submitButtonComponent.gameObject.SetActive(value);
            hintButtonComponent.gameObject.SetActive(value && contents.Length > contentIndex + 1);
        }

        public void Print(string[] contents)
        {
            this.contents = contents;
            contentIndex = 0;

            printCoroutine = StartCoroutine(PrintCoroutine());
        }

        public IEnumerator PrintCoroutine()
        {
            StringBuilder currentContent = new StringBuilder("");
            textComponent.text = currentContent.ToString();

            foreach (char item in contents[contentIndex])
            {
                currentContent.Append(item);
                textComponent.text = currentContent.ToString();
                yield return new WaitForSeconds(printInterval);
            }

            SetOptionsActive(true);
        }

        private void OnClickButton()
        {
            StopPrint();
        }

        private void StopPrint()
        {
            StopCoroutine(printCoroutine);
            textComponent.text = contents[contentIndex];
            SetOptionsActive(true);
        }

        private void OnClickSubmitButton()
        {
            SetOptionsActive(false);
            Debug.Log("빙수 제작 페이지로 이동");
        }

        private void OnClickHintButton()
        {
            SetOptionsActive(false);
            contentIndex++;
            printCoroutine = StartCoroutine(PrintCoroutine());
        }
    }
}