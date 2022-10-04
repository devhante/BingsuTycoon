using BingsuTycoon.Common;
using BingsuTycoon.PlayScene.MakeIce;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BingsuTycoon.PlayScene
{
    public class Bowl : MonoBehaviour
    {
        private AudioSource audioComponent;

        private Vector3 initPos;
        private Vector3 startMousePos;
        private Vector3 endMousePos;
        private Vector3 originPos;
        private Vector3 originLocalPos;
        private Vector3 targetLocalPos;
        private Coroutine moveCoroutine;
        private bool created = false;
        private bool canMakeIce = false;
        private bool canDestroy = false;
        private GameObject makeBingsuPanel;

        private void Awake()
        {
            audioComponent = GetComponent<AudioSource>();

            initPos = transform.position;
            makeBingsuPanel = GameObject.FindGameObjectWithTag("MakeIcePanel");
        }

        public void CreateBowlFromBowls(Vector3 startPos)
        {
            if (created == false)
            {
                created = true;
                transform.position = startPos;
                originPos = transform.position;
                originLocalPos = transform.localPosition;
                targetLocalPos = GameObject.FindGameObjectWithTag("IceMachine").transform.position - (originPos - originLocalPos); ;
                moveCoroutine = StartCoroutine(MoveCoroutine());
            }
        }

        public void DestroyBowl()
        {
            created = false;
            transform.position = initPos;
        }

        private void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                originPos = transform.position;
                originLocalPos = transform.localPosition;
                targetLocalPos = originLocalPos;

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
                endMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (canMakeIce && Mathf.Abs((startMousePos - endMousePos).magnitude) <= 0.1f)
                {
                    makeBingsuPanel.SetActive(true);
                }
                else if (canDestroy)
                {
                    GameManager.Instance.CurrentIngredients = new Ingredients();
                    DestroyBowl();
                    audioComponent.Play();
                }
                else
                {
                    moveCoroutine = StartCoroutine(MoveCoroutine());
                }
            }
        }

        private IEnumerator MoveCoroutine()
        {
            Vector3 startLocalPos = transform.localPosition;
            float value = 0f;

            while (value < 1f)
            {
                float x = EasingFunction.EaseOutQuint(startLocalPos.x, targetLocalPos.x, value);
                float y = EasingFunction.EaseOutQuint(startLocalPos.y, targetLocalPos.y, value);
                transform.localPosition = new Vector3(x, y, transform.localPosition.z);
                value += Time.deltaTime;
                yield return null;
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("BowlContainer"))
            {
                targetLocalPos = collision.transform.position - (originPos - originLocalPos);
            }
            if (collision.CompareTag("IceMachine"))
            {
                canMakeIce = true;
            }
            if (collision.CompareTag("TrashCan"))
            {
                canDestroy = true;
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("BowlContainer"))
            {
                targetLocalPos = originLocalPos;
            }
            if (collision.CompareTag("IceMachine"))
            {
                canMakeIce = false;
            }
            if (collision.CompareTag("TrashCan"))
            {
                canDestroy = false;
            }
        }
    }
}