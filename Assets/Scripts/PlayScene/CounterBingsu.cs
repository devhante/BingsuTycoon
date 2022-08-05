using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterBingsu : MonoBehaviour
{
    private SpriteRenderer srComponent;

    private void Awake()
    {
        srComponent = GetComponent<SpriteRenderer>();
        Disappear();
    }

    public void Appear()
    {
        Color color = srComponent.color;
        color.a = 1;
        srComponent.color = color;
    }

    public void Disappear()
    {
        Color color = srComponent.color;
        color.a = 0;
        srComponent.color = color;
    }
}
