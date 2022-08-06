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

        private bool canClick = false;

        private void Awake()
        {
            bingsuImage = transform.Find("BowlSide").GetComponent<BingsuImage>();
            successArea = transform.Find("Bar").Find("SuccessArea").GetComponent<SuccessArea>();
            handle = transform.Find("Bar").Find("Handle").GetComponent<Handle>();

            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnClick);
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
                GameManager.Instance.CurrentIngredients.IceCount = Mathf.Min(GameManager.Instance.CurrentIngredients.IceCount + 1, 2);
            }
            else
            {
                GameManager.Instance.CurrentIngredients.IceCount = 0;
            }

            bingsuImage.ChangeImage(GameManager.Instance.CurrentIngredients.IceCount);

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