using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.LobbyScene
{
    public class ExitButton : MonoBehaviour
    {
        private Button buttonComponent;
        private AudioSource audioComponent;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            audioComponent = GetComponent<AudioSource>();
            buttonComponent.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            audioComponent.Play();
            Application.Quit();
        }
    }
}