using BingsuTycoon.PlayScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BingsuTycoon.Common
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance = null;

        public int Score { get; set; } = 0;
        public Order CurrentOrder { get; set; }
        public Ingredients CurrentIngredients { get; set; } = new Ingredients();
        public List<string> RevealedOrderList { get; set; } = new List<string>();

        private List<Order> mermaidOrderList = new List<Order>() {
            new Order(
                new Recipe
                (
                    2,
                    false,
                    new Ingredient[]
                    {
                        Ingredient.RedBean
                    },
                    new Ingredient[]
                    {
                        Ingredient.Milk,
                        Ingredient.StrawberrySyrup,
                        Ingredient.ChocolateSyrup,
                        Ingredient.Strawberry,
                        Ingredient.Berry,
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                        Ingredient.CheeseCube,
                        Ingredient.IceCream
                    }
                ),
                new string[] { "���� �߰ſ�!\nCool�� ���� ��� �Ϻ��� ��Ź��!" }
            ),
            new Order(
                new Recipe
                (
                    1,
                    false,
                    new Ingredient[]
                    {
                        Ingredient.Strawberry,
                        Ingredient.IceCream
                        
                    },
                    new Ingredient[]
                    {
                        Ingredient.RedBean,
                        Ingredient.Milk,
                        Ingredient.StrawberrySyrup,
                        Ingredient.ChocolateSyrup,
                        Ingredient.Berry,
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                        Ingredient.CheeseCube,
                        
                    }
                ),
                new string[] { "���� ��� ��ũ���̾�.\n�̷��� �д� �� �³���?", "�βٰ�" }
            ),
            new Order(
                new Recipe
                (
                    1,
                    false,
                    new Ingredient[]
                    {
                        Ingredient.Berry,
                        Ingredient.CheeseCube,
                    },
                    new Ingredient[]
                    {
                        Ingredient.RedBean,
                        Ingredient.Milk,
                        Ingredient.StrawberrySyrup,
                        Ingredient.ChocolateSyrup,
                        Ingredient.Strawberry,
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                        Ingredient.IceCream
                    }
                ),
                new string[] { "�ÿ��� ������ ���ְ� �����شٴ�\n�̾߱⸦ ��� �Ծ��!\n�� ������ų ���� ����ġ�������\n����� �ּ���." }
            )
        };
        private List<Order> catOrderList = new List<Order>() {
            new Order(
                new Recipe
                (
                    1,
                    true,
                    new Ingredient[]
                    {
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                    },
                    new Ingredient[]
                    {
                        Ingredient.RedBean,
                        Ingredient.Strawberry,
                        Ingredient.Berry,
                        Ingredient.CheeseCube,
                        Ingredient.IceCream
                    }
                ),
                new string[] { "�˷���~\nƮ����Į ��Ÿ���� ���� �ϳ� Please!", "�������" }
            ),
            new Order(
                new Recipe
                (
                    1,
                    true,
                    new Ingredient[]
                    {
                        Ingredient.RedBean,
                        Ingredient.Milk,
                        Ingredient.ChocolateSyrup,
                        Ingredient.Berry,
                        Ingredient.CheeseCube,
                    },
                    new Ingredient[]
                    {
                        Ingredient.StrawberrySyrup,
                        Ingredient.Strawberry,
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                        Ingredient.IceCream
                    }
                ),
                new string[] { "������ very very ������!\n���� �÷��÷� >< ���� ���� �÷� �� �־���!", "������, ����÷�" }
            ),
            new Order(
                new Recipe
                (
                    1,
                    true,
                    new Ingredient[]
                    {
                        Ingredient.Milk,
                        Ingredient.StrawberrySyrup,
                        Ingredient.ChocolateSyrup,
                        Ingredient.Strawberry,
                        Ingredient.Berry,
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                        Ingredient.CheeseCube,
                        Ingredient.IceCream
                    },
                    new Ingredient[]
                    {
                        Ingredient.RedBean
                    }
                ),
                new string[] { "�� ���� ��� ��� �� ������!" }
            ),
            new Order(
                new Recipe
                (
                    2,
                    true,
                    new Ingredient[]
                    {
                        Ingredient.Berry,
                    },
                    new Ingredient[]
                    {
                        Ingredient.RedBean,
                        Ingredient.Strawberry,
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                        Ingredient.CheeseCube,
                        Ingredient.IceCream
                    }
                ),
                new string[] { "���䡦 ���ִ� ������\n������ ���� ���� ������� ���� �ּ���.", "���� ������" }
            )
        };
        private List<Order> elfOrderList = new List<Order>() {
            new Order(
                new Recipe
                (
                    2,
                    true,
                    new Ingredient[]
                    {
                        Ingredient.Strawberry,
                        Ingredient.Berry,
                    },
                    new Ingredient[]
                    {
                        Ingredient.RedBean,
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                        Ingredient.CheeseCube,
                        Ingredient.IceCream
                    }
                ),
                new string[] { "�̰��� �����? �̻��� ���ۿ� ���� ������ ����� �Ծ�䡦! �ʹ� ������, ������ �������� �ּ���.", "���� ����" }
            ),
            new Order(
                new Recipe
                (
                    1,
                    false,
                    new Ingredient[]
                    {
                        Ingredient.Mango,
                        Ingredient.CheeseCube
                        
                    },
                    new Ingredient[]
                    {
                        Ingredient.RedBean,
                        Ingredient.Milk,
                        Ingredient.StrawberrySyrup,
                        Ingredient.ChocolateSyrup,
                        Ingredient.Strawberry,
                        Ingredient.Berry,
                        Ingredient.Pineapple,
                        Ingredient.IceCream
                    }
                ),
                new string[] { "������� ġ� �װŸ� ��.\n�� �̻��� ������." }
            ),
            new Order(
                new Recipe
                (
                    1,
                    true,
                    new Ingredient[]
                    {
                        Ingredient.RedBean,
                        Ingredient.ChocolateSyrup,
                    },
                    new Ingredient[]
                    {
                        Ingredient.Milk,
                        Ingredient.StrawberrySyrup,
                        Ingredient.Strawberry,
                        Ingredient.Berry,
                        Ingredient.Pineapple,
                        Ingredient.Mango,
                        Ingredient.CheeseCube,
                        Ingredient.IceCream
                    }
                ),
                new string[] { "�ϡ� �ϻ��� ���� ���. �˺��� ����\n�� ��ο� ���� ����.\n��ο� �� ������ �ɷ� ��Ź��." }
            )
        };

        private string[] mermaidGreatText = new string[]
        {
            "���� ���ִ� ��������. ������!",
            "�ÿ��� ���� �Ծȿ� �����ؿ�. ������������.",
            "��~ �� �� ����.\n�������� ���� ������ ���Ϳ�!",
            "���� ������! �����̴�~"
        };
        private string[] mermaidGoodText = new string[]
        {
            "���� ���ֳ׿�.",
            "���п� �ÿ��������.",
            "��¦ ���������� �׷��� ���ƿ�!",
        };
        private string[] mermaidBadText = new string[]
        {
            "���� �Ը��� �������� ���γ׿�.",
            "(�ݷ�) �̰� ��������?",
            "�̵��� ������� �ǰ���?!"
        };
        private string[] catGreatText = new string[]
        {
            "�� 100��!! �ʹ� ���־�~",
            "����~ �����Ѱ� ���� �� �����̾�.",
            "�������� �������� taste! JMT!!!",
            "õ����! ���� ������ ���ٳ�~"
        };
        private string[] catGoodText = new string[]
        {
            "������, ���� ���ϴ� �� �̰� �ƴѰ�?",
            "�졦 �� �򰡴� normal���̿���.",
            "������ ��̵� ���� �������",
        };
        private string[] catBadText = new string[]
        {
            "�̰� �� ������� ����ų�?!",
            "���, �̷��� ������ ����� �͵� �������.",
            "�� ���� ���޾Ҿ�! �� �������� ���̾�.",
            "��, �ٽô� �ȿ´� �޷�!"
        };
        private string[] elfGreatText = new string[]
        {
            "�����! ���� �޲ٴ� �׸��̿���!",
            "����! ������ �����̱���!",
            "ļ! ���� ã�� �� �׸��̿���~",
            "�������ִ١�. �������� �� �ðԿ�."
        };
        private string[] elfGoodText = new string[]
        {
            "�׷������� ������ �ϳ׿�. ������",
            "������ �ʾƿ䡦",
            "��, ���� �ƽ����� �� �����Կ�.",
        };
        private string[] elfBadText = new string[]
        {
            "���ǡ�. ����� ���� �� ���ƿ�.",
            "(�ʡ� �� ���١�) ���� ������.",
            "�˼�������, ���� ���ϴ� ������ �ƴϳ׿�.",
        };

        public int BingsuCount { get; set; } = 0;

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
            
            // DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            GameObject.FindGameObjectWithTag("CustomerSpawner").GetComponent<CustomerSpawner>().SpawnRandomCustomer(1);
        }

        public void SetRandomOrder(Customer.CustomerType customerType)
        {
            switch (customerType)
            {
                case Customer.CustomerType.Mermaid:
                    CurrentOrder = mermaidOrderList[Random.Range(0, mermaidOrderList.Count)];
                    break;
                case Customer.CustomerType.Cat:
                    CurrentOrder = catOrderList[Random.Range(0, catOrderList.Count)];
                    break;
                case Customer.CustomerType.Elf:
                    CurrentOrder = elfOrderList[Random.Range(0, elfOrderList.Count)];
                    break;
            }
        }

        public string GetRandomReceiveText(Customer.CustomerType customerType, int score)
        {
            string[] resultArray = new string[] { };

            switch (customerType)
            {
                case Customer.CustomerType.Mermaid:
                    if (score >= 80)
                        resultArray = mermaidGreatText;
                    else if (score >= 40)
                        resultArray = mermaidGoodText;
                    else
                        resultArray = mermaidBadText;
                    break;
                case Customer.CustomerType.Cat:
                    if (score >= 80)
                        resultArray = catGreatText;
                    else if (score >= 40)
                        resultArray = catGoodText;
                    else
                        resultArray = catBadText;
                    break;
                case Customer.CustomerType.Elf:
                    if (score >= 80)
                        resultArray = elfGreatText;
                    else if (score >= 40)
                        resultArray = elfGoodText;
                    else
                        resultArray = elfBadText;
                    break;
                default:
                    break;
            }

            return resultArray[Random.Range(0, resultArray.Length)];
        }

        private int rankACount = 0;
        private int mermaidSCount = 0;
        private int catSCount = 0;
        private int elfSCuont = 0;
        private int rankDFCount = 0;

        public void UpdateAchieve(Customer.CustomerType customerType, int score)
        {
            if (score >= 80)
            {
                rankACount++;
            }
            if (customerType == Customer.CustomerType.Mermaid && score >= 100)
            {
                mermaidSCount++;
            }
            if (customerType == Customer.CustomerType.Cat && score >= 100)
            {
                catSCount++;
            }
            if (customerType == Customer.CustomerType.Elf && score >= 100)
            {
                elfSCuont++;
            }
            if (score <= 20)
            {
                rankDFCount++;
            }

            if (rankACount >= 5 && AchieveManager.Instance.AchieveData[0] == false)
            {
                AchieveManager.Instance.Achieve(0);
            }
            if (rankACount >= 7 && AchieveManager.Instance.AchieveData[1] == false)
            {
                AchieveManager.Instance.Achieve(1);
            }
            if (rankACount >= 8 && AchieveManager.Instance.AchieveData[2] == false)
            {
                AchieveManager.Instance.Achieve(2);
            }
            if (rankACount >= 10 && AchieveManager.Instance.AchieveData[3] == false)
            {
                AchieveManager.Instance.Achieve(3);
            }
            if (BingsuCount >= 10 && AchieveManager.Instance.AchieveData[4] == false)
            {
                AchieveManager.Instance.Achieve(4);
            }
            if (mermaidSCount >= 3 && AchieveManager.Instance.AchieveData[5] == false)
            {
                AchieveManager.Instance.Achieve(5);
            }
            if (elfSCuont >= 3 && AchieveManager.Instance.AchieveData[7] == false)
            {
                AchieveManager.Instance.Achieve(7);
            }
            if (catSCount >= 3 && AchieveManager.Instance.AchieveData[6] == false)
            {
                AchieveManager.Instance.Achieve(6);
            }
        }

        public bool isRankAllDF()
        {
            return rankDFCount == BingsuCount;
        }
    }

}