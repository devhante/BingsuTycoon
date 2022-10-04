using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSound : MonoBehaviour
{
    private AudioSource touchSound;

    private void Awake()
    {
        touchSound = GameObject.FindGameObjectWithTag("TouchSound").GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            touchSound.Play();
        }
    }
}
