using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BingsuTycoon.PlayScene
{
    public class Bowls : MonoBehaviour
    {
        private Vector3 startMousePos;
        private Vector3 endMousePos;

        private void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        private void OnMouseUp()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                endMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Mathf.Abs((startMousePos - endMousePos).magnitude) <= 0.1f)
                {
                    OnClick();
                }
            }
        }

        private void OnClick()
        {
            Bowl bowl = GameObject.FindGameObjectWithTag("Bowl").GetComponent<Bowl>();
            bowl.CreateBowlFromBowls(transform.position);
        }
    }
}