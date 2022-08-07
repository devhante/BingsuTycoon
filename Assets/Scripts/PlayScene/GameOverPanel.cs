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
        private TMP_Text averageScoreTextComponent;
        private Image rankImageComponent;
        private Button submitButtonComponent;
        private Button restartButtonComponent;

        private void Awake()
        {
            gameOverImageComponent = transform.Find("GameOverImage").GetComponent<Image>();
            resultPanel = transform.Find("ResultPanel").gameObject;

            bingsuCountTextComponent = resultPanel.transform.Find("BingsuCountText").GetComponent<TMP_Text>();
            averageScoreTextComponent = resultPanel.transform.Find("AverageScoreText").GetComponent<TMP_Text>();
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

            float averageScore = 0;
            if (GameManager.Instance.BingsuCount > 0)
            {
                averageScore = GameManager.Instance.Score / GameManager.Instance.BingsuCount;
            }

            bingsuCountTextComponent.text = "판매한 빙수 개수: " + GameManager.Instance.BingsuCount;
            averageScoreTextComponent.text = "평균 만족도: " + averageScore + "%";
            rankImageComponent.sprite = GetRankImage(averageScore);
            gameOverImageComponent.gameObject.SetActive(false);
            resultPanel.SetActive(true);
        }

        private Sprite GetRankImage(float averageScore)
        {
            if (averageScore >= 100)
                return rankImages[0];
            else if (averageScore >= 80)
                return rankImages[1];
            else if (averageScore >= 60)
                return rankImages[2];
            else if (averageScore >= 40)
                return rankImages[3];
            else if (averageScore >= 20)
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