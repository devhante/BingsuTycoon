using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.PlayScene
{
    public class FinishMakingButton : MonoBehaviour
    {
        private Button buttonComponent;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(OnClickButton);
        }

        private void OnClickButton()
        {
            GameObject.FindGameObjectWithTag("CounterBingsu").GetComponent<CounterBingsu>().Appear();
            GameObject.FindGameObjectWithTag("MakeScreen").GetComponent<MakeScreen>().Disappear();
        }
    }
}