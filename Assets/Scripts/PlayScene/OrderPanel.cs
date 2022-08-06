using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

namespace BingsuTycoon.PlayScene
{
    public class OrderPanel : MonoBehaviour
    {
        private TMP_Text textComponent;

        private void Awake()
        {
            textComponent = transform.Find("OrderText").GetComponent<TMP_Text>();
        }

        private void Update()
        {
            StringBuilder result = new StringBuilder();
            foreach (string item in GameManager.Instance.RevealedOrderList)
            {
                result.Append(item + "\n");
            }

            textComponent.text = result.ToString();
        }
    }
}