using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour
{
    public Profile[] profiles;

    private Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        foreach (var item in profiles)
        {
            if (item.CanMove) item.MoveRight();
        }
    }
}
