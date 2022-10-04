using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientClickSound : MonoBehaviour
{
    private AudioSource ingredientClickSound;

    private void Awake()
    {
        ingredientClickSound = GameObject.FindGameObjectWithTag("IngredientClickSound").GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            ingredientClickSound.Play();
        }
    }
}
