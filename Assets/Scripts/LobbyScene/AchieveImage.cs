using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BingsuTycoon.LobbyScene
{
    public class AchieveImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public int achieveId;
        public Sprite achieveImage;
        public Sprite questionImage;
        public GameObject TitleObject;

        private Image imageComponent;

        private void Awake()
        {
            imageComponent = GetComponent<Image>();
        }

        private void Update()
        {
            if (AchieveManager.Instance.AchieveData[achieveId] == true)
            {
                imageComponent.sprite = achieveImage;
            }
            else
            {
                imageComponent.sprite = questionImage;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (AchieveManager.Instance.AchieveData[achieveId] == true)
            {
                TitleObject.SetActive(true);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            TitleObject.SetActive(false);
        }
    }
}