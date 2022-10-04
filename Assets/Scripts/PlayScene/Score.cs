using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BingsuTycoon.Common;

namespace BingsuTycoon.PlayScene
{
    public class Score : MonoBehaviour
    {
        private TMP_Text textComponent;

        private void Awake()
        {
            textComponent = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            textComponent.text = "Score: " + GameManager.Instance.Score;
        }
    }
}