using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene.MakeIce
{
    public class Handle : MonoBehaviour
    {
        private RectTransform rtComponent;

        private float speed = 490f;
        private float minPos = -245f;
        private float maxPos = 245f;

        private bool isMovingUp = true;

        private void Awake()
        {
            rtComponent = GetComponent<RectTransform>();
        }

        public void StartMove()
        {
            if (rtComponent)
            {
                StartCoroutine(MoveCoroutine());
            }
        }

        public void StopMove()
        {
            StopAllCoroutines();
        }

        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                Vector3 direction = isMovingUp ? Vector3.up : Vector3.down;
                Vector3 pos = rtComponent.anchoredPosition;
                pos.y = Mathf.Clamp(pos.y + (direction.y * speed * Time.smoothDeltaTime), minPos, maxPos);
                rtComponent.anchoredPosition = pos;
                if (pos.y == minPos) isMovingUp = true;
                else if (pos.y == maxPos) isMovingUp = false;
                yield return null;
            }
        }
    }
}