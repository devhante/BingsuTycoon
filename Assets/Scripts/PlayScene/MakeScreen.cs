using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace BingsuTycoon.PlayScene
{
    public class MakeScreen : MonoBehaviour
    {
        private Vector3 appearPos = new Vector3(2, 0, 0);
        private Vector3 disappearPos = new Vector3(30, 0, 0);

        private Transform leftPos;
        private Transform rightPos;

        private Vector3 prevMousePos;
        private Vector3 curMousePos;

        private Vector3 offset;

        private void Awake()
        {
            leftPos = transform.Find("LeftPos").transform;
            rightPos = transform.Find("RightPos").transform;
        }

        private void OnMouseDown()
        {
            Debug.Log("MakeScreen OnMouseDown");
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                prevMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                StartCoroutine(DragCoroutine());
            }
        }

        private IEnumerator DragCoroutine()
        {
            while (Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    curMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 leftViewPos = Camera.main.WorldToViewportPoint(leftPos.position);
                    Vector3 rightViewPos = Camera.main.WorldToViewportPoint(rightPos.position);
                    if ((curMousePos.x > prevMousePos.x && leftViewPos.x < 0) || (curMousePos.x < prevMousePos.x && rightViewPos.x > 1))
                    {
                        float resultPositionX = transform.position.x + curMousePos.x - prevMousePos.x;
                        transform.position = new Vector3(resultPositionX, transform.position.y, transform.position.z);
                    }
                    prevMousePos = curMousePos;
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