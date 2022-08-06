using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene.MakeIce
{
    public class SuccessArea : MonoBehaviour
    {
        private RectTransform rtComponent;

        private float height;
        private float minPos = -160f;
        private float maxPos = 160;

        private void Awake()
        {
            rtComponent = GetComponent<RectTransform>();
            height = rtComponent.sizeDelta.y;
        }

        public void MoveRandomly()
        {
            if (rtComponent)
            {
                Vector3 pos = rtComponent.anchoredPosition;
                pos.y = Random.Range(minPos, maxPos);
                rtComponent.anchoredPosition = pos;
            }
        }

        public bool isSucceeded(float posY)
        {
            Vector3 pos = rtComponent.anchoredPosition;
            return posY >= pos.y - (height * 0.5f) && posY <= pos.y + (height * 0.5f);
        }
    }
}