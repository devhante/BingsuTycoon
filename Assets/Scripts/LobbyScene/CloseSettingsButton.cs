using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseSettingsButton : MonoBehaviour
{
    private Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
