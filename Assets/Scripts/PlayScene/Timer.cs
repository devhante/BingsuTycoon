using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.PlayScene
{
    public class Timer : MonoBehaviour
    {
        private Slider sliderComponent;
        private AudioSource audioComponent;
        private GameOverPanel gameOverPanel;

        private float currentTime = 0f;
        private float timeLimit = 180f;
        private bool audioPlaying = false;

        private void Awake()
        {
            sliderComponent = GetComponent<Slider>();
            audioComponent = GetComponent<AudioSource>();
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

            while (currentTime > 0)
            {
                currentTime = Mathf.Max(currentTime - Time.smoothDeltaTime, 0f);
                sliderComponent.value = currentTime / timeLimit;

                if (audioPlaying == false && currentTime <= 30f)
                {
                    audioComponent.Play();
                    audioPlaying = true;
                }
                yield return null;
            }

            audioComponent.Stop();
            Time.timeScale = 0;
            gameOverPanel.gameObject.SetActive(true);
            gameOverPanel.PrintResult();
        }
    }
}