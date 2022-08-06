using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BingsuTycoon.LobbyScene
{
    public class StartButton : MonoBehaviour
    {
        private Button buttonComponent;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}