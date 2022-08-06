using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene
{
    public class DraggableIngredient : MonoBehaviour
    {
        public bool CanUse { get; set; } = false;

        public void StartDrag()
        {
            StartCoroutine(GetComponent<Draggable>().DragCoroutine());
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bowl"))
            {
                CanUse = true;
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Bowl"))
            {
                CanUse = false;
            }
        }
    }
}