using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.PlayScene.MakeIce
{
    public class MakeIcePanel : MonoBehaviour
    {
        private Button buttonComponent;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnClick);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnClick()
        {
            gameObject.SetActive(false);
        }
    }
}