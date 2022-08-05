using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    private GameObject result;
    private TMP_Text gameOverTextComponent;
    private TMP_Text bingsuCountTextComponent;
    private Button submitButtonComponent;
    private Button restartButtonComponent;

    private void Awake()
    {
        gameOverTextComponent = transform.Find("GameOverText").GetComponent<TMP_Text>();
        result = transform.Find("Result").gameObject;

        bingsuCountTextComponent = result.transform.Find("BingsuCountText").GetComponent<TMP_Text>();
        submitButtonComponent = result.transform.Find("SubmitButton").GetComponent<Button>();
        restartButtonComponent = result.transform.Find("RestartButton").GetComponent<Button>();

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
        result.SetActive(false);
        StartCoroutine(PrintResultCoroutine());
    }

    private IEnumerator PrintResultCoroutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        bingsuCountTextComponent.text = "판매한 빙수 개수 : " + GameManager.Instance.BingsuCount;
        gameOverTextComponent.gameObject.SetActive(false);
        result.SetActive(true);
    }

    private void OnClickSubmitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }

    private void OnClickRestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }
}
