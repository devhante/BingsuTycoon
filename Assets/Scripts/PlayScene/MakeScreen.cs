using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace BingsuTycoon.PlayScene
{
    public class MakeScreen : MonoBehaviour
    {
        private Vector3 appearPos = new Vector3(4, 0, 0);
        private Vector3 disappearPos = new Vector3(20, 0, 0);

        private Transform leftPos;
        private Transform rightPos;

        private Vector3 prevTouchPos;
        private Vector3 curTouchPos;

        private void Awake()
        {
            leftPos = transform.Find("LeftPos").transform;
            rightPos = transform.Find("RightPos").transform;
        }

        private void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                prevTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                StartCoroutine(DragCoroutine());
            }
        }

        private IEnumerator DragCoroutine()
        {
            while(Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    curTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float diff = curTouchPos.x - prevTouchPos.x;

                    if (diff > 0f)
                    {
                        Vector3 pos = Camera.main.WorldToViewportPoint(leftPos.position);
                        Debug.Log("leftPos = " + pos);
                        if (pos.x + diff > 0f)
                        {
                            diff = 0f - pos.x;
                        }
                    }
                    else if (diff < 0f)
                    {
                        Vector3 pos = Camera.main.WorldToViewportPoint(rightPos.position);
                        Debug.Log("rightPos = " + pos);
                        if (pos.x + diff < 1f)
                        {
                            diff = 1 - pos.x;
                        }
                    }

                    float resultPosX = transform.position.x + diff;
                    transform.position = new Vector3(resultPosX, transform.position.y, transform.position.z);
                    prevTouchPos = curTouchPos;
                    yield return null;
                }
            }
        }

        public void Appear()
        {
            StartCoroutine(AppearCoroutine());
        }

        private IEnumerator AppearCoroutine()
        {
            float value = 0f;

            while (value < 1f)
            {
                float x = EasingFunction.EaseOutQuint(disappearPos.x, appearPos.x, value);
                float y = EasingFunction.EaseOutQuint(disappearPos.y, appearPos.y, value);
                transform.position = new Vector3(x, y, transform.position.z);
                value += Time.deltaTime;
                yield return null;
            }
        }

        public void Disappear()
        {
            StartCoroutine(DisappearCoroutine());
        }

        private IEnumerator DisappearCoroutine()
        {
            float value = 0f;

            while (value < 1f)
            {
                float x = EasingFunction.EaseOutQuint(appearPos.x, disappearPos.x, value);
                float y = EasingFunction.EaseOutQuint(appearPos.y, disappearPos.y, value);
                transform.position = new Vector3(x, y, transform.position.z);
                value += Time.deltaTime;
                yield return null;
            }
        }
    }
}