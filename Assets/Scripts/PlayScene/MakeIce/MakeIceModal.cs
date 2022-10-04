using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.PlayScene.MakeIce
{
    public class MakeIceModal : MonoBehaviour
    {
        private BingsuImage bingsuImage;
        private SuccessArea successArea;
        private Handle handle;
        private Button buttonComponent;
        private AudioSource audioComponent;
        private AudioSource succeededAudioComponent;
        private AudioSource failedAudioComponent;

        private bool canClick = false;

        private void Awake()
        {
            bingsuImage = transform.Find("BowlSide").GetComponent<BingsuImage>();
            successArea = transform.Find("Bar").Find("SuccessArea").GetComponent<SuccessArea>();
            handle = transform.Find("Bar").Find("Handle").GetComponent<Handle>();

            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnClick);
            audioComponent = GetComponent<AudioSource>();
            succeededAudioComponent = transform.Find("SucceededAudio").GetComponent<AudioSource>();
            failedAudioComponent = transform.Find("FailedAudio").GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            StartCoroutine(StartMiniGameCoroutine(0f));
        }

        private void OnClick()
        {
            if (canClick)
            {
                MakeIce();
            }
        }

        private void MakeIce()
        {
            handle.StopMove();
            if (successArea.isSucceeded(handle.GetComponent<RectTransform>().anchoredPosition.y)) {
                if (GameManager.Instance.CurrentIngredients.IceCount < 2)
                {
                    GameManager.Instance.CurrentIngredients.IceCount++;
                }
                audioComponent.Play();
                succeededAudioComponent.Play();
            }
            else
            {
                GameManager.Instance.CurrentIngredients.IceCount = 0;
                failedAudioComponent.Play();
            }

            StartCoroutine(StartMiniGameCoroutine(1f));
        }

        private IEnumerator StartMiniGameCoroutine(float idle)
        {
            canClick = false;
            yield return new WaitForSeconds(idle);
            successArea.MoveRandomly();
            handle.StartMove();
            canClick = true;
        }
    }
}