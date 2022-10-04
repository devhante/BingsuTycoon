using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public Sprite[] sprites;

    private int index = 0;
    private Image imageComponent;
    private Button buttonComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);
    }

    public void ShowHowToPlay(int index)
    {
        imageComponent.sprite = sprites[index];
    }

    private void OnClick()
    {
        index++;
        if (index < sprites.Length)
        {
            ShowHowToPlay(index);
        }
        else
        {
            index = 0;
            ShowHowToPlay(index);
            GameObject.FindGameObjectWithTag("HowToPlayCanvas").SetActive(false);
        }
    }
}
