using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public GameObject settingsPanel;

    private Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }
}
