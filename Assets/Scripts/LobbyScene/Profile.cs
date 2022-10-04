using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    public bool CanMove { get; set; } = true;

    private RectTransform rtComponent;

    private float leftPosX = -2500;
    private float rightPosX = 2500;

    private Vector3 startPos;
    private Vector3 endPos;

    private void Awake()
    {
        rtComponent = GetComponent<RectTransform>();
    }

    public void MoveLeft()
    {
        CanMove = false;

        startPos = rtComponent.anchoredPosition;
        endPos = startPos + new Vector3(2500f, 0, 0);

        StartCoroutine(MoveCoroutine());
    }

    public void MoveRight()
    {
        CanMove = false;

        startPos = rtComponent.anchoredPosition;
        endPos = startPos + new Vector3(-2500f, 0, 0);

        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        float value = 0f;

        while (value < 1f)
        {
            float x = EasingFunction.EaseOutQuint(startPos.x, endPos.x, value);
            float y = EasingFunction.EaseOutQuint(startPos.y, endPos.y, value);
            rtComponent.anchoredPosition = new Vector2(x, y);
            value += Time.deltaTime;
            yield return null;
        }

        if (rtComponent.anchoredPosition.x >= 3000)
        {
            rtComponent.anchoredPosition = new Vector3(leftPosX, rtComponent.anchoredPosition.y);
        }
        else if (rtComponent.anchoredPosition.x <= -3000)
        {
            rtComponent.anchoredPosition = new Vector3(rightPosX, rtComponent.anchoredPosition.y);
        }

        CanMove = true;
    }
}
