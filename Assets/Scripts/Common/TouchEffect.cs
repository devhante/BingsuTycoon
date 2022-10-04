using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    private RectTransform parentRectTransform;
    private Canvas parentCanvas;
    private Animator animatorComponent;

    private void Awake()
    {
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
        parentCanvas = transform.parent.GetComponent<Canvas>();
        animatorComponent = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, parentCanvas.worldCamera, out pos);
            transform.localPosition = pos;

            StopAllCoroutines();
            StartCoroutine(TouchCoroutine());
        }
    }

    private IEnumerator TouchCoroutine()
    {
        animatorComponent.SetBool("StopAnim", true);
        animatorComponent.SetBool("Touch", false);
        yield return new WaitForSeconds(0.1f);
        animatorComponent.SetBool("StopAnim", false);
        animatorComponent.SetBool("Touch", true);
        yield return new WaitForSeconds(0.1f);
        animatorComponent.SetBool("Touch", false);
    }
}
