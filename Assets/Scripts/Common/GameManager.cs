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
                new string[] { "�ÿ��� ������ ���ְ� �����شٴ� �̾߱⸦ ��� �Ծ��!\n�� ������ų ���� ����ġ������� ����� �ּ���." }
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
                new string[] { "�˷���~ Ʈ����Į ��Ÿ���� ���� �ϳ� Please!", "�������" }
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
                new string[] { "���䡦 ���ִ� ������ ������ ���� ���� ������� ���� �ּ���.", "���� ������" }
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
                new string[] { "�ϡ� �ϻ��� ���� ���. �˺��� ����\n�� ��ο� ���� ����. ��ο� �� ������ �ɷ� ��Ź��." }
            )
        };

        private string[] mermaidGreatText = new string[]
        {
            "���� ���ִ� ��������. ������!",
            "�ÿ��� ���� �Ծȿ� �����ؿ�. ������������.",
            "��~ �� �� ����. �������� ���� ������ ���Ϳ�!",
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
    }

}