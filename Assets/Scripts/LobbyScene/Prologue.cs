using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    public Button buttonComponent;

    private void Awake()
    {
        if (PlayerPrefs.GetString("Prologue") == "False")
        {
            gameObject.SetActive(false);
        }

        buttonComponent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        PlayerPrefs.SetString("Prologue", "False");
        gameObject.SetActive(false);
    }
}
