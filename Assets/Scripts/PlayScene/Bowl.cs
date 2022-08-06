using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowl : MonoBehaviour
{
    private Vector3 startMousePos;
    private Vector3 endMousePos;
    private Vector3 originPos;
    private Vector3 originLocalPos;
    private Vector3 targetLocalPos;
    private Coroutine moveCoroutine;
    private bool canMakeIce = false;


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
            if (startMousePos == endMousePos)
            {
                Debug.Log("TOUCH");
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
    }
}
