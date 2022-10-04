using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchSound : MonoBehaviour
{
    private Button buttonComponent;
    private AudioSource touchSound;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        touchSound = GameObject.FindGameObjectWithTag("TouchSound").GetComponent<AudioSource>();
        buttonComponent.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        touchSound.Play();
    }
}
