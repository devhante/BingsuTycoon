using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BingsuTycoon.Common;

namespace BingsuTycoon.PlayScene
{
    public class AchieveBar : MonoBehaviour
    {
        private RectTransform rtComponent;
        private TMP_Text textComponent;
        private float appearPosY = -60f;
        private float disappearPosY = 160f;

        private void Awake()
        {
            rtComponent = GetComponent<RectTransform>();
            textComponent = transform.Find("Text").GetComponent<TMP_Text>();
        }

        public void Appear(int achieveId)
        {
            textComponent.text = "\"" + AchieveManager.Instance.GetAchieveTitle(achieveId) + "\" ´Þ¼º!";
            StartCoroutine(MoveCoroutine());
        }

        private IEnumerator MoveCoroutine()
        {
            float value = 0f;

            while (value < 1f)
            {
                float y = EasingFunction.EaseOutQuint(disappearPosY, appearPosY, value);
                rtComponent.anchoredPosition = new Vector2(rtComponent.anchoredPosition.x, y);
                value += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSecondsRealtime(2f);

            value = 0f;

            while (value < 1f)
            {
                float y = EasingFunction.EaseOutQuint(appearPosY, disappearPosY, value);
                rtComponent.anchoredPosition = new Vector2(rtComponent.anchoredPosition.x, y);
                value += Time.deltaTime;
                yield return null;
            }
        }
    }
}