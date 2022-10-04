using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace BingsuTycoon.PlayScene
{
    public class GameOverPanel : MonoBehaviour
    {
        public Sprite[] rankImages;

        private Image gameOverImageComponent;

        private GameObject resultPanel;
        private TMP_Text bingsuCountTextComponent;
        private TMP_Text scoreTextComponent;
        private Image rankImageComponent;
        private Button submitButtonComponent;
        private Button restartButtonComponent;

        private void Awake()
        {
            gameOverImageComponent = transform.Find("GameOverImage").GetComponent<Image>();
            resultPanel = transform.Find("ResultPanel").gameObject;

            bingsuCountTextComponent = resultPanel.transform.Find("BingsuCountText").GetComponent<TMP_Text>();
            scoreTextComponent = resultPanel.transform.Find("ScoreText").GetComponent<TMP_Text>();
            rankImageComponent = resultPanel.transform.Find("RankImage").GetComponent<Image>();
            submitButtonComponent = resultPanel.transform.Find("SubmitButton").GetComponent<Button>();
            restartButtonComponent = resultPanel.transform.Find("RestartButton").GetComponent<Button>();

            submitButtonComponent.onClick.AddListener(OnClickSubmitButton);
            restartButtonComponent.onClick.AddListener(OnClickRestartButton);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void PrintResult()
        {
            bingsuCountTextComponent.gameObject.SetActive(true);
            resultPanel.SetActive(false);
            StartCoroutine(PrintResultCoroutine());
        }

        private IEnumerator PrintResultCoroutine()
        {
            yield return new WaitForSecondsRealtime(2f);

            bingsuCountTextComponent.text = "판매한 빙수: " + GameManager.Instance.BingsuCount;
            scoreTextComponent.text = "점수: " + GameManager.Instance.Score;
            rankImageComponent.sprite = GetRankImage();
            gameOverImageComponent.gameObject.SetActive(false);
            resultPanel.SetActive(true);
        }

        private Sprite GetRankImage()
        {
            int score = GameManager.Instance.Score;

            if (score >= 500)
                return rankImages[0];
            else if (score >= 450)
                return rankImages[1];
            else if (score >= 400)
                return rankImages[2];
            else if (score >= 350)
                return rankImages[3];
            else if (score >= 300)
                return rankImages[4];
            else
                return rankImages[5];
        }

        private void OnClickSubmitButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("LobbyScene");
        }

        private void OnClickRestartButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("PlayScene");
        }
    }
}