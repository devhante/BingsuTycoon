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
        private AudioSource audioComponent;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            audioComponent = GetComponent<AudioSource>();
            buttonComponent.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            StartCoroutine(OnClickCoroutine());
        }

        private IEnumerator OnClickCoroutine()
        {
            audioComponent.Play();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("PlayScene");
        }
    }
}