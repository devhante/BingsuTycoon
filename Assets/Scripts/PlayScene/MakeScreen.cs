using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace BingsuTycoon.PlayScene
{
    public class MakeScreen : MonoBehaviour
    {
        private Vector3 appearPos = new Vector3(0, 0, 0);
        private Vector3 disappearPos = new Vector3(20, 0, 0);

        // TEST CODE START

        private Vector3 prevTouchPos;
        private Vector3 curTouchPos;

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
                    float resultPosX = transform.position.x + curTouchPos.x - prevTouchPos.x;
                    resultPosX = Mathf.Clamp(resultPosX, -8.34f, 1.67f);
                    transform.position = new Vector3(resultPosX, transform.position.y, transform.position.z);
                    prevTouchPos = curTouchPos;
                    yield return null;
                }
            }
        }

        // TEST CODE END

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