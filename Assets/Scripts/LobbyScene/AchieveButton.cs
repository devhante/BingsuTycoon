using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveButton : MonoBehaviour
{
    private Button buttonComponent;
    private GameObject achieveCanvas;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);
        achieveCanvas = GameObject.FindGameObjectWithTag("AchieveCanvas").gameObject;
    }

    private void Start()
    {
        achieveCanvas.SetActive(false);
    }

    private void OnClick()
    {
        achieveCanvas.SetActive(true);
    }
}
