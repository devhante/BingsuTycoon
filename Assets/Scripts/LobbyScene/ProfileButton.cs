using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.LobbyScene
{
    public class ProfileButton : MonoBehaviour
    {
        private Button buttonComponent;
        private GameObject profileCanvas;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnClick);
            profileCanvas = GameObject.FindGameObjectWithTag("ProfileCanvas").gameObject;
        }

        private void Start()
        {
            profileCanvas.SetActive(false);
        }

        private void OnClick()
        {
            profileCanvas.SetActive(true);
        }
    }
}