using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene
{
    public class IngredientController : MonoBehaviour
    {
        private GameObject lowIce;
        private GameObject lowMilk;
        private GameObject lowSyrupChocolate;
        private GameObject lowSyrupStrawberry;
        private GameObject lowToppingRedBean;
        private GameObject lowToppingMango;
        private GameObject lowToppingCheese;
        private GameObject lowToppingMangoCheese;
        private GameObject lowToppingIceCream;
        private GameObject highIce;
        private GameObject highMilk;
        private GameObject highSyrupChocolate;
        private GameObject highSyrupStrawberry;
        private GameObject highToppingRedBean;
        private GameObject highToppingMango;
        private GameObject highToppingCheese;
        private GameObject highToppingMangoCheese;
        private GameObject highToppingIceCream;

        private void Awake()
        {
            lowIce = transform.GetChild(0).gameObject;
            lowMilk = transform.GetChild(1).gameObject;
            lowSyrupChocolate = transform.GetChild(2).gameObject;
            lowSyrupStrawberry = transform.GetChild(3).gameObject;
            lowToppingRedBean = transform.GetChild(4).gameObject;
            lowToppingMango = transform.GetChild(5).gameObject;
            lowToppingCheese = transform.GetChild(6).gameObject;
            lowToppingMangoCheese = transform.GetChild(7).gameObject;
            lowToppingIceCream = transform.GetChild(8).gameObject;
            highIce = transform.GetChild(9).gameObject;
            highMilk = transform.GetChild(10).gameObject;
            highSyrupChocolate = transform.GetChild(11).gameObject;
            highSyrupStrawberry = transform.GetChild(12).gameObject;
            highToppingRedBean = transform.GetChild(13).gameObject;
            highToppingMango = transform.GetChild(14).gameObject;
            highToppingCheese = transform.GetChild(15).gameObject;
            highToppingMangoCheese = transform.GetChild(16).gameObject;
            highToppingIceCream = transform.GetChild(17).gameObject;
        }

        private void Update()
        {
            Ingredients i = GameManager.Instance.CurrentIngredients;
            lowIce.SetActive(i.IceCount == 1);
            lowMilk.SetActive(i.IceCount == 1 && i.Milk);
            lowSyrupChocolate.SetActive(i.IceCount == 1 && i.ChocolateSyrup);
            lowSyrupStrawberry.SetActive(i.IceCount == 1 && i.StrawberrySyrup);
            lowToppingRedBean.SetActive(i.IceCount == 1 && i.RedBean);
            lowToppingMango.SetActive(i.IceCount == 1 && i.Mango && !i.CheeseCube);
            lowToppingCheese.SetActive(i.IceCount == 1 && i.CheeseCube && !i.Mango);
            lowToppingMangoCheese.SetActive(i.IceCount == 1 && i.Mango && i.CheeseCube);
            lowToppingIceCream.SetActive(i.IceCount == 1 && i.IceCream);

            highIce.SetActive(i.IceCount == 2);
            highMilk.SetActive(i.IceCount == 2 && i.Milk);
            highSyrupChocolate.SetActive(i.IceCount == 2 && i.ChocolateSyrup);
            highSyrupStrawberry.SetActive(i.IceCount == 2 && i.StrawberrySyrup);
            highToppingRedBean.SetActive(i.IceCount == 2 && i.RedBean);
            highToppingMango.SetActive(i.IceCount == 2 && i.Mango && !i.CheeseCube);
            highToppingCheese.SetActive(i.IceCount == 2 && i.CheeseCube && !i.Mango);
            highToppingMangoCheese.SetActive(i.IceCount == 2 && i.Mango && i.CheeseCube);
            highToppingIceCream.SetActive(i.IceCount == 2 && i.IceCream);
        }
    }
}