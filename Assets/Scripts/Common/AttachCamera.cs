using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.Common
{
    public class AttachCamera : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }
}