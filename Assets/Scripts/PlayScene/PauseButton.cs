using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button buttonComponent;
    private GameObject pausePanel;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);

        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
    }

    private void OnClick()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
}
