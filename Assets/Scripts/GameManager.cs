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

                speechBubble.Print("�̰��� �����? �̻��� ���ۿ� ����\n������ ����� �Ծ��...!\n�ʹ� ������! ������ �������� �ּ���!");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("��ǳ�� ��ü�� ���� ��� ��¿� �����߽��ϴ�.");
            }
        }

    }

}