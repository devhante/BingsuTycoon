using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Syrup : MonoBehaviour
{
    public Ingredient ingredientType;

    public bool CanUse { get; set; } = false;

    private Vector3 originLocalPos;
    private Coroutine moveCoroutine;

    private Vector3 originRotation = Vector3.zero;
    private Vector3 originScale = Vector3.one;

    private Vector3 draggingRotation = new Vector3(0f, 0f, 135f);
    private Vector3 draggingScale = new Vector3(-1, 1, 1);

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            transform.rotation = Quaternion.Euler(draggingRotation);
            transform.localScale = draggingScale;

            originLocalPos = transform.localPosition;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
        }
    }

    private void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            transform.rotation = Quaternion.Euler(originRotation);
            transform.localScale = originScale;

            if (CanUse)
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

            moveCoroutine = StartCoroutine(MoveCoroutine());
        }
    }

    private IEnumerator MoveCoroutine()
    {
        Vector3 startLocalPos = transform.localPosition;
        float value = 0f;

        while (value < 1f)
        {
            float x = EasingFunction.EaseOutQuint(startLocalPos.x, originLocalPos.x, value);
            float y = EasingFunction.EaseOutQuint(startLocalPos.y, originLocalPos.y, value);
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
            value += Time.deltaTime;
            yield return null;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bowl"))
        {
            CanUse = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bowl"))
        {
            CanUse = false;
        }
    }
}
