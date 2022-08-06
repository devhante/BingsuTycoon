using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BingsuTycoon.PlayScene
{
    public class PausePanel : MonoBehaviour
    {
        private Button resumeButtonComponent;
        private Button restartButtonComponent;
        private Button exitButtonComponent;

        private void Awake()
        {
            resumeButtonComponent = transform.Find("ResumeButton").GetComponent<Button>();
            restartButtonComponent = transform.Find("RestartButton").GetComponent<Button>();
            exitButtonComponent = transform.Find("ExitButton").GetComponent<Button>();

            resumeButtonComponent.onClick.AddListener(OnClickResumeButton);
            restartButtonComponent.onClick.AddListener(OnClickRestartButton);
            exitButtonComponent.onClick.AddListener(OnClickExitButton);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnClickResumeButton()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        private void OnClickRestartButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("PlayScene");
        }

        private void OnClickExitButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("LobbyScene");
        }
    }
}