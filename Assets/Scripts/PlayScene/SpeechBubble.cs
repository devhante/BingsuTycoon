using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BingsuTycoon.Common;

namespace BingsuTycoon.PlayScene
{
    public class SpeechBubble : MonoBehaviour
    {
        public enum SpeechType { Order, Receive }

        private Button buttonComponent;
        private TMP_Text textComponent;

        private Button submitOrderButtonComponent;
        private Button hintButtonComponent;
        private Button submitReceiveButtonComponent;

        private float printInterval = 0.05f;
        private SpeechType speechType;
        private string[] contents;
        private int contentIndex = 0;
        private Coroutine printCoroutine;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            textComponent = transform.Find("Text").GetComponent<TMP_Text>();
            submitOrderButtonComponent = transform.Find("SubmitOrderButton").GetComponent<Button>();
            hintButtonComponent = transform.Find("HintButton").GetComponent<Button>();
            submitReceiveButtonComponent = transform.Find("SubmitReceiveButton").GetComponent<Button>();

            buttonComponent.onClick.AddListener(OnClickButton);
            submitOrderButtonComponent.onClick.AddListener(OnClickSubmitOrderButton);
            hintButtonComponent.onClick.AddListener(OnClickHintButton);
            submitReceiveButtonComponent.onClick.AddListener(OnClickSubmitReceiveButton);

            SetOptionsActive(SpeechType.Order, false);
            SetOptionsActive(SpeechType.Receive, false);
        }

        private void SetOptionsActive(SpeechType speechType, bool value)
        {
            switch (speechType)
            {
                case SpeechType.Order:
                    submitOrderButtonComponent.gameObject.SetActive(value);
                    hintButtonComponent.gameObject.SetActive(value && contents.Length > contentIndex + 1);
                    break;
                case SpeechType.Receive:
                    submitReceiveButtonComponent.gameObject.SetActive(value);
                    break;
            }
        }

        public void Print(SpeechType speechType, string[] contents)
        {
            this.speechType = speechType;
            this.contents = contents;
            contentIndex = 0;

            printCoroutine = StartCoroutine(PrintCoroutine());
        }

        public IEnumerator PrintCoroutine()
        {
            GameManager.Instance.RevealedOrderList.Add(contents[contentIndex]);
            StringBuilder currentContent = new StringBuilder("");
            textComponent.text = currentContent.ToString();

            foreach (char item in contents[contentIndex])
            {
                currentContent.Append(item);
                textComponent.text = currentContent.ToString();
                yield return new WaitForSeconds(printInterval);
            }

            SetOptionsActive(speechType, true);
        }

        private void OnClickButton()
        {
            StopPrint();
        }

        private void StopPrint()
        {
            StopCoroutine(printCoroutine);
            textComponent.text = contents[contentIndex];
            SetOptionsActive(speechType, true);
        }

        private void OnClickSubmitOrderButton()
        {
            SetOptionsActive(speechType, false);
            GameObject.FindGameObjectWithTag("MakeScreen").GetComponent<MakeScreen>().Appear();
            gameObject.SetActive(false);
        }

        private void OnClickHintButton()
        {
            SetOptionsActive(speechType, false);
            contentIndex++;
            printCoroutine = StartCoroutine(PrintCoroutine());
        }

        private void OnClickSubmitReceiveButton()
        {
            SetOptionsActive(speechType, false);
            GameObject.FindGameObjectWithTag("Customer").GetComponent<Customer>().Disappear();
            gameObject.SetActive(false);
        }
    }
}