using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BingsuTycoon.PlayScene
{
    public class Contained : MonoBehaviour
    {
        public Ingredient ingredientType;

        private DraggableIngredient draggableIngredient;

        private void Awake()
        {
            draggableIngredient = transform.GetChild(0).GetComponent<DraggableIngredient>();
            draggableIngredient.gameObject.SetActive(false);
        }

        private void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                draggableIngredient.gameObject.SetActive(true);
                draggableIngredient.transform.position = new Vector3(mousePos.x, mousePos.y, draggableIngredient.transform.position.z);
                draggableIngredient.StartDrag();
            }
        }

        private void OnMouseUp() 
        {
            if (draggableIngredient.CanUse)
            {
                switch (ingredientType)
                {
                    case Ingredient.Milk:
                        GameManager.Instance.CurrentIngredients.Milk = true;
                        break;
                    case Ingredient.RedBean:
                        GameManager.Instance.CurrentIngredients.RedBean = true;
                        break;
                    case Ingredient.StrawberrySyrup:
                        GameManager.Instance.CurrentIngredients.StrawberrySyrup = true;
                        break;
                    case Ingredient.ChocolateSyrup:
                        GameManager.Instance.CurrentIngredients.ChocolateSyrup = true;
                        break;
                    case Ingredient.Strawberry:
                        GameManager.Instance.CurrentIngredients.Strawberry = true;
                        break;
                    case Ingredient.Berry:
                        GameManager.Instance.CurrentIngredients.Berry = true;
                        break;
                    case Ingredient.Pineapple:
                        GameManager.Instance.CurrentIngredients.Pineapple = true;
                        break;
                    case Ingredient.Mango:
                        GameManager.Instance.CurrentIngredients.Mango = true;
                        break;
                    case Ingredient.CheeseCube:
                        GameManager.Instance.CurrentIngredients.CheeseCube = true;
                        break;
                    case Ingredient.IceCream:
                        GameManager.Instance.CurrentIngredients.IceCream = true;
                        break;
                    default:
                        break;
                }
            }

            draggableIngredient.gameObject.SetActive(false);
        }
    }
}