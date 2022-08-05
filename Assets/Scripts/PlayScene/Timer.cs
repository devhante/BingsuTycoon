using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider sliderComponent;
    private GameOverPanel gameOverPanel;

    private float currentTime = 0f;
    private float timeLimit = 120f;

    private void Awake()
    {
        sliderComponent = GetComponent<Slider>();
        gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel").GetComponent<GameOverPanel>();
    }

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        currentTime = timeLimit;

        while(currentTime > 0)
        {
            currentTime = Mathf.Max(currentTime - Time.smoothDeltaTime, 0f);
            sliderComponent.value = currentTime / timeLimit;
            yield return null;
        }

        Time.timeScale = 0;
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.PrintResult();
    }
}
