using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(DragCoroutine());
        }
    }

    public IEnumerator DragCoroutine()
    {
        while (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector3 resultPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                transform.position = new Vector3(resultPosition.x, resultPosition.y, transform.position.z);
            }
            yield return null;
        }
    }
}
