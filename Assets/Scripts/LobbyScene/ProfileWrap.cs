using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileWrap : MonoBehaviour
{
    private Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameObject.FindGameObjectWithTag("ProfileCanvas").gameObject.SetActive(false);
    }
}
