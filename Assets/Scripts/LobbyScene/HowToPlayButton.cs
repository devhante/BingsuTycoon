using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.LobbyScene
{
    public class HowToPlayButton : MonoBehaviour
    {
        private Button buttonComponent;
        private GameObject howToPlayCanvas;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnClick);
            howToPlayCanvas = GameObject.FindGameObjectWithTag("HowToPlayCanvas").gameObject;
        }

        private void Start()
        {
            howToPlayCanvas.SetActive(false);
        }

        private void OnClick()
        {
            howToPlayCanvas.SetActive(true);
        }
    }
}