using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderButton : MonoBehaviour
{
    private GameObject panelObject;
    private Button buttonComponent;
    private bool isPanelVisible = false;

    private void Awake()
    {
        panelObject = transform.Find("OrderPanel").gameObject;
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);

        panelObject.SetActive(isPanelVisible);
    }

    private void OnClick()
    {
        isPanelVisible = !isPanelVisible;
        panelObject.SetActive(isPanelVisible);
    }
}
