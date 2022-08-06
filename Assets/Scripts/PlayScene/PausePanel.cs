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

        private void Awake()
        {
            resumeButtonComponent = transform.Find("ResumeButton").GetComponent<Button>();
            restartButtonComponent = transform.Find("RestartButton").GetComponent<Button>();

            resumeButtonComponent.onClick.AddListener(OnClickResumeButton);
            restartButtonComponent.onClick.AddListener(OnClickRestartButton);
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
    }
}