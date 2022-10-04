using BingsuTycoon.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene
{
    public class Customer : MonoBehaviour
    {
        public enum CustomerType { Mermaid, Cat, Elf }

        public CustomerType customerType;

        public Sprite defaultSprite;
        public Sprite greatSprite;
        public Sprite goodSprite;
        public Sprite badSprite;

        private SpriteRenderer srComponent;
        private AudioSource audioComponent;
        private SpeechBubble speechBubble;

        private float appearTime = 1f;

        private void Awake()
        {
            srComponent = transform.Find("Sprite").GetComponent<SpriteRenderer>();
            audioComponent = GetComponent<AudioSource>();
            speechBubble = transform.Find("CustomerCanvas").Find("SpeechBubble").GetComponent<SpeechBubble>();

            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            speechBubble.gameObject.SetActive(false);
            AppearAndOrder();
        }

        private void AppearAndOrder()
        {
            StartCoroutine(AppearAndOrderCoroutine());
        }

        private IEnumerator AppearAndOrderCoroutine()
        {
            float alpha = 0f;
            srComponent.color = new Color(srComponent.color.r, srComponent.color.g, srComponent.color.b, alpha);

            while (alpha < 1f)
            {
                alpha = Mathf.Min(alpha + Time.smoothDeltaTime / appearTime, 1f);
                srComponent.color = new Color(srComponent.color.r, srComponent.color.g, srComponent.color.b, alpha);
                yield return null;
            }

            Order();
        }

        private void Order()
        {
            GameManager.Instance.SetRandomOrder(customerType);
            string[] orderText = GameManager.Instance.CurrentOrder.OrderTextArray;

            speechBubble.gameObject.SetActive(true);
            speechBubble.Print(SpeechBubble.SpeechType.Order, orderText);
        }

        public void Receive()
        {
            int wrongNumber = GameManager.Instance.CurrentOrder.OrderRecipe.GetWrongNumber(GameManager.Instance.CurrentIngredients);
            int score = Mathf.Max(100 - (wrongNumber * 20), 0);
            GameManager.Instance.Score += score;
            GameManager.Instance.BingsuCount++;

            GameManager.Instance.UpdateAchieve(customerType, score);
            audioComponent.Play();

            if (score >= 80) ChangeSpriteToGreat();
            else if (score >= 40) ChangeSpriteToGood();
            else ChangeSpriteToBad();

            speechBubble.gameObject.SetActive(true);
            speechBubble.Print(SpeechBubble.SpeechType.Receive, new string[] {
                GameManager.Instance.GetRandomReceiveText(customerType, score)
            });
        }

        public void Disappear()
        {
            GameObject.FindGameObjectWithTag("Bowl").GetComponent<Bowl>().DestroyBowl();
            GameManager.Instance.CurrentIngredients = new Ingredients();
            GameManager.Instance.RevealedOrderList = new List<string>();
            StartCoroutine(DisappearCoroutine());
        }

        private IEnumerator DisappearCoroutine()
        {
            float alpha = 1f;
            srComponent.color = new Color(srComponent.color.r, srComponent.color.g, srComponent.color.b, alpha);

            while (alpha > 0f)
            {
                alpha = Mathf.Max(alpha - Time.smoothDeltaTime / appearTime, 0f);
                srComponent.color = new Color(srComponent.color.r, srComponent.color.g, srComponent.color.b, alpha);
                yield return null;
            }

            yield return new WaitForSeconds(1f);
            GameObject.FindGameObjectWithTag("CustomerSpawner").GetComponent<CustomerSpawner>().SpawnRandomCustomer(1);
            ChangeSpriteToDefault();
            gameObject.SetActive(false);
        }

        public void ChangeSpriteToDefault()
        {
            srComponent.sprite = defaultSprite;
        }

        public void ChangeSpriteToGreat()
        {
            srComponent.sprite = greatSprite;
        }

        public void ChangeSpriteToGood()
        {
            srComponent.sprite = goodSprite;
        }

        public void ChangeSpriteToBad()
        {
            srComponent.sprite = badSprite;
        }
    }
}