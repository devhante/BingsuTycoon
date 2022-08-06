using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.PlayScene.MakeIce
{
    public class BingsuImage : MonoBehaviour
    {
        public Sprite[] iceImageList;

        private Image iceImageComponent;

        private void Awake()
        {
            iceImageComponent = transform.Find("BowlSideIce").GetComponent<Image>();
        }

        private void Start()
        {
            ChangeImage(0);
        }

        public void ChangeImage(int iceCount)
        {
            if (iceCount < iceImageList.Length)
            {
                iceImageComponent.sprite = iceImageList[iceCount];
            }
        }
    }
}