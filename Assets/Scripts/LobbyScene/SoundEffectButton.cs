using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.LobbyScene
{
    public class SoundEffectButton : MonoBehaviour
    {
        public Sprite onSprite;
        public Sprite offSprite;

        private Image imageComponent;
        private Button buttonComponent;

        private void Awake()
        {
            imageComponent = GetComponent<Image>();
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SoundManager.Instance.SoundEffect = !SoundManager.Instance.SoundEffect;
        }

        private void Update()
        {
            if (SoundManager.Instance.SoundEffect == true)
            {
                imageComponent.sprite = onSprite;
            }
            else
            {
                imageComponent.sprite = offSprite;
            }
        }
    }
}