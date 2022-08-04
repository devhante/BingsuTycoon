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
                "이곳은 어디죠? 이상한 구멍에 빨려\n들어갔더니 여기로 왔어요...!\n너무 더워요! 달콤한 간얼음을 주세요!",
                "너무 더워요! 달콤한 간얼음을 주세요!",
                "너무 더워요! 달콤한 간얼음을 주세요!"
            });
        }
    }
}