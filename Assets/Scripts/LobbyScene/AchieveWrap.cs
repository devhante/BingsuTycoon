using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveWrap : MonoBehaviour
{
    private Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameObject.FindGameObjectWithTag("AchieveCanvas").gameObject.SetActive(false);
    }
}
