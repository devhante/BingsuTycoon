using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BingsuTycoon.PlayScene.MakeIce
{
    public class BingsuImage : MonoBehaviour
    {
        private Animator animatorComponent;

        private void Awake()
        {
            animatorComponent = GetComponent<Animator>();
        }

        private void Update()
        {
            animatorComponent.SetInteger("IceCount", GameManager.Instance.CurrentIngredients.IceCount);
        }
    }
}