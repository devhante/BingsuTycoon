using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene
{
    public class Customer : MonoBehaviour
    {
        private SpriteRenderer srComponent;
        private SpeechBubble speechBubble;

        private float appearTime = 2f;

        private void Awake()
        {
            srComponent = GetComponent<SpriteRenderer>();
            speechBubble = transform.Find("Canvas").Find("SpeechBubble").GetComponent<SpeechBubble>();

            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            speechBubble.gameObject.SetActive(false);
            Appear();
        }

        private void Appear()
        {
            StartCoroutine(AppearCoroutine());
        }

        private IEnumerator AppearCoroutine()
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
            speechBubble.Print(new string[] {
                "�̰��� �����? �̻��� ���ۿ� ����\n������ ����� �Ծ��...!\n�ʹ� ������! ������ �������� �ּ���!",
                "�ʹ� ������! ������ �������� �ּ���!",
                "�ʹ� ������! ������ �������� �ּ���!"
            });
        }
    }
}