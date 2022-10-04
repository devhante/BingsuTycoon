using BingsuTycoon.PlayScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.Common
{
    public class AchieveManager : MonoBehaviour
    {
        private static AchieveManager instance = null;

        public static AchieveManager Instance
        {
            get
            {
                return instance;
            }
        }

        public bool[] AchieveData { get; set; } = new bool[9];

        private void Awake()
        {
            if (instance)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;

            LoadAchieveData();
        }

        private void LoadAchieveData()
        {
            string achieve = PlayerPrefs.GetString("Achieve");

            if (achieve.Length != 9)
            {
                achieve = "000000000";
            }

            int index = 0;
            foreach (var item in achieve)
            {
                if (item == '0')
                {
                    AchieveData[index] = false;
                }
                else if (item == '1')
                {
                    AchieveData[index] = true;
                }
                index++;
            }
        }

        private void SaveAchieveData()
        {
            string achieve = "";

            foreach (var item in AchieveData)
            {
                achieve += item ? "1" : "0";
            }

            PlayerPrefs.SetString("Achieve", achieve);
            PlayerPrefs.Save();
        }

        public string GetAchieveTitle(int achieveId)
        {
            string[] titles = new string[9]
            {
                "������ ����",
                "���� ���",
                "���� ������",
                "������ ��",
                "������ ������",
                "�ξ� ��������",
                "������ ����� �����մϴ�!",
                "�縣�� ��Ҵٳ�",
                "���� 0.0"
            };

            return titles[achieveId];
        }

        public void Achieve(int achieveId)
        {
            GameObject.FindGameObjectWithTag("AchieveBar").GetComponent<AchieveBar>().Appear(achieveId);
            AchieveData[achieveId] = true;
            SaveAchieveData();
        }
    }
}