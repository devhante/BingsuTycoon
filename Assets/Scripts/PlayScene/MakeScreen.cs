using BingsuTycoon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BingsuTycoon.PlayScene
{
    public class MakeScreen : MonoBehaviour
    {
        private Vector3 appearPos = new Vector3(0, 0, 0);
        private Vector3 disappearPos = new Vector3(20, 0, 0);

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