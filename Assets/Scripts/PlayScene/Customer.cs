using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene
{
    public class Customer : MonoBehaviour
    {
        private SpriteRenderer srComponent;
        private SpeechBubble speechBubble;

        private float appearTime = 1.5f;

        private void Awake()
        {
            srComponent = transform.Find("Sprite").GetComponent<SpriteRenderer>();
            speechBubble = transform.Find("Canvas").Find("SpeechBubble").GetComponent<SpeechBubble>();

            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            speechBubble.gameObject.SetActive(false);
            AppearAndOrder();
        }

        private void AppearAndOrder()
        {
            StartCoroutine(AppearAndOrderCoroutine());
        }

        private IEnumerator AppearAndOrderCoroutine()
        {
            float alpha = 0f;
            srComponent.color = new Color(srComponent.color.r, srComponent.color.g, srComponent.color.b, alpha);

            while (alpha < 1f)
            {
                alpha = Mathf.Min(alpha + Time.smoothDeltaTime / appearTime, 1f);
                srComponent.color = new Color(srComponent.color.r, srComponent.color.g, srComponent.color.b, alpha);
                yield return null;
            }

            Order();
        }

        private void Order()
        {
            speechBubble.gameObject.SetActive(true);
            speechBubble.Print(SpeechBubble.SpeechType.Order, new string[] {
                "�̰��� �����? �̻��� ���ۿ� ����\n������ ����� �Ծ��...!\n�ʹ� ������! ������ �������� �ּ���!",
                "�ʹ� ������! ������ �������� �ּ���!",
                "�ʹ� ������! ������ �������� �ּ���!"
            });
        }

        public void Receive()
        {
            GameManager.Instance.BingsuCount++;
            speechBubble.gameObject.SetActive(true);
            speechBubble.Print(SpeechBubble.SpeechType.Receive, new string[] {
                "��~ ���ְڴ�!"
            });
        }

        public void Disappear()
        {
            StartCoroutine(DisappearCoroutine());
        }

        private IEnumerator DisappearCoroutine()
        {
            float alpha = 1f;
            srComponent.color = new Color(srComponent.color.r, srComponent.color.g, srComponent.color.b, alpha);

            while (alpha > 0f)
            {
                alpha = Mathf.Max(alpha - Time.smoothDeltaTime / appearTime, 0f);
                srComponent.color = new Color(srComponent.color.r, srComponent.color.g, srComponent.color.b, alpha);
                yield return null;
            }

            yield return new WaitForSeconds(1f);
            GameObject.FindGameObjectWithTag("CustomerSpawner").GetComponent<CustomerSpawner>().SpawnRandomCustomer(1);
            gameObject.SetActive(false);
        }
    }
}