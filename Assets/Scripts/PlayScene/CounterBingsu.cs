using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BingsuTycoon.PlayScene
{
    public class CounterBingsu : MonoBehaviour
    {
        private SpriteRenderer srComponent;

        private Vector3 originPos;
        private bool canGive;
        private Coroutine moveCoroutine;

        private void Awake()
        {
            srComponent = GetComponent<SpriteRenderer>();
            originPos = transform.position;
            Disappear();
        }

        public void Appear()
        {
            Color color = srComponent.color;
            color.a = 1;
            srComponent.color = color;
        }

        public void Disappear()
        {
            Color color = srComponent.color;
            color.a = 0;
            srComponent.color = color;
        }

        private void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (moveCoroutine != null)
                {
                    StopCoroutine(moveCoroutine);
                }
            }
        }

        private void OnMouseUp()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (canGive)
                {
                    Disappear();
                    GameObject.FindGameObjectWithTag("Customer").GetComponent<Customer>().Receive();
                }
                moveCoroutine = StartCoroutine(MoveOriginPosCoroutine());
            }
        }

        private IEnumerator MoveOriginPosCoroutine()
        {
            Vector3 startPos = transform.position;
            float value = 0f;

            while (value < 1f)
            {
                float x = EasingFunction.EaseOutQuint(startPos.x, originPos.x, value);
                float y = EasingFunction.EaseOutQuint(startPos.y, originPos.y, value);
                transform.position = new Vector3(x, y, transform.position.z);
                value += Time.deltaTime;
                yield return null;
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Customer"))
            {
                canGive = true;
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Customer"))
            {
                canGive = false;
            }
        }
    }
}