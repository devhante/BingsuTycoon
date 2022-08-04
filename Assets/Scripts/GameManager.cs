using BingsuTycoon.PlayScene;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BingsuTycoon
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance = null;

        public static GameManager Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if (instance)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            TestSpeechBubble();
        }

        private void TestSpeechBubble()
        {
            try
            {
                SpeechBubble speechBubble = GameObject.FindGameObjectWithTag("SpeechBubble").GetComponent<SpeechBubble>();
                if (speechBubble == null)
                {
                    throw new NullReferenceException();
                }

                speechBubble.Print("이곳은 어디죠? 이상한 구멍에 빨려\n들어갔더니 여기로 왔어요...!\n너무 더워요! 달콤한 간얼음을 주세요!");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("말풍선 객체가 없어 대사 출력에 실패했습니다.");
            }
        }

    }

}