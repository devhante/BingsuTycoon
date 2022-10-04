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
                new string[] { "정말 뜨거워!\nCool한 얼음 듬뿍 팥빙수 부탁해!" }
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
                new string[] { "수빙 기딸 림크스이아.\n이렇게 읽는 게 맞나요?", "로꾸거" }
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
                new string[] { "시원한 얼음을 맛있게 갈아준다는\n이야기를 듣고 왔어요!\n절 만족시킬 만한 베리치즈빙수를\n만들어 주세요." }
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
                new string[] { "알로하~\n트로피칼 스타일의 빙수 하나 Please!", "열대과일" }
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
                new string[] { "베리… very very 좋아해!\n딸기 시럽시럽 >< 딸기 빼고 시럽 다 넣어줘!", "베리굿, 딸기시럽" }
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
                new string[] { "팥 빼고 모든 재료 다 섞어줘!" }
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
                new string[] { "헉헉… 맛있는 빙수…\n베리를 넣은 더블 사이즈로 많이 주세요.", "더블 사이즈" }
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
                new string[] { "이곳은 어디죠? 이상한 구멍에 빨려 들어갔더니 여기로 왔어요…! 너무 더워요, 달콤한 간얼음을 주세요.", "얼음 많이" }
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
                new string[] { "망고랑… 치즈… 그거면 돼.\n더 이상은 괜찮아." }
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
                new string[] { "팥… 팥색이 맘에 들어. 검붉은 색…\n난 어두운 색이 좋아.\n어두운 색 달콤한 걸로 부탁해." }
            )
        };

        private string[] mermaidGreatText = new string[]
        {
            "정말 맛있는 빙수에요. 고마워요!",
            "시원한 맛이 입안에 가득해요. 만족스러워요.",
            "휴~ 살 것 같다.\n지느러미 춤이 저절로 나와요!",
            "맛의 쓰나미! 해일이다~"
        };
        private string[] mermaidGoodText = new string[]
        {
            "음… 맛있네요.",
            "덕분에 시원해졌어요.",
            "살짝 부족하지만 그래도 좋아요!",
        };
        private string[] mermaidBadText = new string[]
        {
            "음… 입맛만 떨어지고 별로네요.",
            "(콜록) 이걸 먹으라고요?",
            "이딴게 빙수라는 건가요?!"
        };
        private string[] catGreatText = new string[]
        {
            "와 100점!! 너무 맛있어~",
            "으흠~ 달콤한게 완전 내 취향이야.",
            "진심으로 감동적인 taste! JMT!!!",
            "천재적! 빙수 마스터 고맙다냥~"
        };
        private string[] catGoodText = new string[]
        {
            "하지만, 내가 원하던 건 이게 아닌걸?",
            "흠… 내 평가는 normal맛이에요.",
            "감동도 재미도 없는 노잼맛…",
        };
        private string[] catBadText = new string[]
        {
            "이걸 나 먹으라고 만든거냥?!",
            "우와, 이렇게 맛없게 만드는 것도 재능이죠.",
            "나 지금 열받았어! 더 더워지는 맛이야.",
            "흥, 다시는 안온다 메롱!"
        };
        private string[] elfGreatText = new string[]
        {
            "우오와! 제가 꿈꾸던 그맛이에요!",
            "흠흠! 빙수에 진심이군요!",
            "캬! 제가 찾던 딱 그맛이에요~",
            "마…맛있다…. 다음에도 또 올게요."
        };
        private string[] elfGoodText = new string[]
        {
            "그럭저럭… 먹을만 하네요. 고마워요",
            "나쁘지 않아요…",
            "흠, 뭔가 아쉽지만 잘 먹을게요.",
        };
        private string[] elfBadText = new string[]
        {
            "으악…. 흙맛이 나는 것 같아요.",
            "(켁… 맛 없다…) ㅎㅎ 고마워요.",
            "죄송하지만, 제가 원하는 빙수는 아니네요.",
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