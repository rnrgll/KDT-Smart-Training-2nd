namespace LevelTest1_Advance
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 문제1_FindKeyIndex
            Console.WriteLine("-----문제 1-----");
            //문제 1 테스트 케이스
            Console.WriteLine(FindKeyIndex("abcdef", 'd'));
            Console.WriteLine(FindKeyIndex("Winner winner chicken dinner", 'c'));
            Console.WriteLine(FindKeyIndex("Not your lucky day", 'p'));
            Console.WriteLine();
            #endregion


            #region 문제2_IsPrime
            Console.WriteLine("-----문제 2-----");

            Console.WriteLine(IsPrime(7));
            Console.WriteLine(IsPrime(4));
            Console.WriteLine(IsPrime(1));
            Console.WriteLine();

            #endregion


            #region 문제3_SumOfDigits
            Console.WriteLine("-----문제 3-----");

            Console.WriteLine(SumOfDigits(18234));
            Console.WriteLine(SumOfDigits(3849));
            Console.WriteLine(SumOfDigits(12345));
            Console.WriteLine();

            #endregion

            #region 문제4_FindCommonItems
            Console.WriteLine("-----문제 4-----");

            int[] arr1 = { 1, 5, 5, 10 };
            int[] arr2 = { 3, 5, 5, 10 };
            PrintIntArr(FindCommonItems(arr1, arr2)); //5, 10

            int[] arr3 = { 3, 5, 7, 9 };
            int[] arr4 = { 7, 6, 5, 4, };
            PrintIntArr(FindCommonItems(arr3, arr4)); //5, 7


            int[] arr5 = { 8, 7, 6, 5 };
            int[] arr6 = { 1, 2, 3, 4 };
            PrintIntArr(FindCommonItems(arr5, arr6)); //null

            int[] test1 = { 1, 7, 6, 3 };
            int[] test2 = { 2, 3, 7, 6, 6, 9 };
            PrintIntArr(FindCommonItems(test1, test2)); // 3, 6, 7


            int[] test3 = { 1, 7, 6, 3, -11 };
            int[] test4 = { -11, 3, 7, 6, 0, -3, 6, 9 };
            PrintIntArr(FindCommonItems(test3, test4)); // -11, 3, 6, 7

            Console.WriteLine();

            #endregion

            #region 문제5_FindClosetNumber
            Console.WriteLine("-----문제 5-----");

            int[] arr7 = { 3, 10, 28 };
            int[] arr8 = { 10, 11, 12 };
            int[] arr9 = { 1, 2, 3, 4, 5 };

            Console.WriteLine(FindClosetNumber(arr7, 20));
            Console.WriteLine(FindClosetNumber(arr8, 15));
            Console.WriteLine(FindClosetNumber(arr9, 3));

            Console.WriteLine();

            #endregion

            #region 문제6_FindModeNumber
            Console.WriteLine("-----문제 6-----");
            int[] test11 = { 1, 2, 3, 3, 3, 3, 4 };
            int[] test12 = { 1, 99, 99, 55, 32, 14 };
            int[] test13 = { 11 };

            Console.WriteLine(FindModeNumber(test11));
            Console.WriteLine(FindModeNumber(test12));
            Console.WriteLine(FindModeNumber(test13));
            Console.WriteLine();

            #endregion

            #region 문제7_숫자야구게임
            Console.WriteLine("-----문제 7-----");

            NumberBaseballGame();
            Console.WriteLine();

            #endregion

            #region 문제8_상점게임
            Console.WriteLine("-----문제 8-----");
            StoreGame();
            Console.WriteLine();
            #endregion

        }




        //문제 1 : 주어진 문자열 중 찾는 문자가 있는 인덱스를 구하는 함수를 작성하시오. 단, 없을 경우 -1을 출력하시오.
        public static int FindKeyIndex(string text, char key)
        {
            int idx = -1;


            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == key)
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }




        //문제 2 : 주어진 숫자가 소수인지 판별하는 함수를 작성하시오.
        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }


        //문제3 : 주어진 숫자의 각 자리수의 합을 구하는 함수를 작성하시오.
        public static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }


        //문제4 : 주어진 두 배열에서 공통항목을 찾는 함수를 작성하시오. 단, 중복은 허용하지 않는다.
        //다시풀기//
        public static int[] FindCommonItems(int[] arr1, int[] arr2)
        {
            int minLen = Math.Min(arr1.Length, arr2.Length);
            int[] commonItems = new int[minLen];
            int idx = 0;
            int lastIdx = 0;

            Array.Sort(arr1);
            Array.Sort(arr2);
            for (int i = 0; i < arr1.Length; i++)
            {

                for (; lastIdx < arr2.Length; lastIdx++)
                {
                    //정렬했으므로 배열1의 값 배열2의 값보다 작은 경우, 배열 2의 나머지 요소들과 당연히 같지 않음.
                    if (arr1[i] < arr2[lastIdx]) break;


                    if (arr1[i] == arr2[lastIdx] && arr1[i] != commonItems[Math.Max(0, idx - 1)])
                    {
                        commonItems[idx++] = arr1[i];
                        lastIdx++;

                        break;
                    }
                    
                }
            }

            int[] result = new int[idx];
            for (int i = 0; i < idx; i++)
            {
                result[i] = commonItems[i];
            }

            return result;
        }

        public static void PrintIntArr(int[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("null");
                return;
            }

            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i != arr.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine(" }");
        }



        //문제 5: 주어진 배열에서 주어진 숫자와 가장 가까운 수를 구하는 함수를 작성하시오.
        public static int FindClosetNumber(int[] array, int number)
        {
            int minOffset = int.MaxValue;
            int closetNumber = 0;
            foreach (int n in array)
            {
                int offset = (int)MathF.Abs(n - number);
                if (minOffset > offset)
                {
                    minOffset = offset;
                    closetNumber = n;
                }
            }

            return closetNumber;

        }

        //문제 6 : 주어진 배열에서 가장 자주 나오는 값인 최빈값을 구하는 함수를 작성하시오.
        //단, 최빈값이 여러개인 경우 가장 작은 값을 구한다.
        public static int FindModeNumber(int[] array)
        {
            //빈도수를 저장할 배열의 길이를 정하기 위해 주어진 배열에서 가장 큰 값을 구한다.
            int maxVal = int.MinValue;
            foreach (int n in array)
            {
                if (maxVal < n)
                    maxVal = n;
            }


            //빈도수 저장용 배열
            int[] freq = new int[maxVal + 1];

            //빈도수 계산
            foreach (int n in array)
            {
                freq[n]++;
            }

            //최빈값 구하기
            int modeNum = 0, maxCount = 0;
            for (int i = 0; i <= maxVal; i++)
            {
                if (maxCount < freq[i])
                {
                    maxCount = freq[i];
                    modeNum = i;
                }
            }


            return modeNum;

        }




        //문제 7 : 숫자야구 게임 만들기


        public static void NumberBaseballGame()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("************* 숫자 야구 **************");
            Console.WriteLine("**************************************");
            Console.WriteLine();

            int cnt = 0;


            //1. 컴퓨터는 1~9 중 랜덤한 4자리 숫자를 뽑는다. (중복 허용하지 않도록!)
            Random random = new Random();
            string answer = "";
            int[] nums = new int[10];
            int pickCnt = 4;
            while (pickCnt > 0)
            {
                int n = random.Next(1, 10);
                if (nums[n] == 0)
                {
                    nums[n] = 1;
                    pickCnt--;
                    answer += n.ToString();
                }


            }


            //2. 유저는 10번의 기회가 있다.
            while (cnt < 10)
            {
                //3.플레이어가 수를 입력하면 조건에 맞추어 결과를 알려준다
                //Ball : 자리수는 다르지만 포함된 경우
                //Strike : 자리수와 값이 동일한 경우
                //Out : 숫자가 하나도 맞지 않을 경우
                //HomeRun : 모든 숫자가 자리수와 값이 동일한 경우

                string input = "";

                while (!int.TryParse(input, out int n) || input.Length != 4)
                {
                    Console.WriteLine($"======={cnt + 1} 번째 기회=======");
                    Console.Write("숫자를 입력하세요 : ");
                    input = Console.ReadLine();
                }


                int[] result = CheckAnswer(answer, input);
                if (result[0] == 4)
                {
                    Console.WriteLine("Home Run!");
                    Console.WriteLine("승리했습니다!");
                    return;
                }
                else if (result[0] == 0 && result[1] == 0)
                {
                    Console.WriteLine("Out!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Strike : {result[0]}\tBall : {result[1]}");
                    Console.WriteLine();
                }

                cnt++;

            }

            Console.WriteLine("모든 기회를 소진했습니다. 패배했습니다.");


        }

        public static int[] CheckAnswer(string answer, string input)
        {
            int[] result = new int[2];
            int ball = 0;
            int strike = 0;
            for (int i = 0; i < 4; i++)
            {
                if (answer[i] == input[i])
                {
                    strike++;
                }
                else if (answer.Contains(input[i]))
                {
                    ball++;
                }
            }
            result[0] = strike;
            result[1] = ball;
            return result;





        }


        //문제 8 : 상점 게임
        //구현 리스트
        //- 아이템 구조체 (완)
        //- 플레이어 구조체 (완)
        //- 아이템 구매 기능 (완)
        //- 아이템 판매 기능
        //- 아이템 확인 기능 (완)



        //아이템 구조체
        public struct Item
        {
            public string name;
            public string description;
            public int price;
            public int atrValue;
            public Attribute attribute;

            /// <summary>
            /// 아이템 생성자
            /// </summary>
            /// <param name="name">아이템 이름</param>
            /// <param name="description">아이템 설명</param>
            /// <param name="price">아이템 가격</param>
            /// <param name="attValue">아이템 보유 효과</param>
            /// <param name="attribute">아이템 보유 효과 타입?</param>
            public Item(string name, string description, int price, int attValue, Attribute attribute)
            {
                this.name = name;
                this.description = description;
                this.price = price;
                this.atrValue = attValue;
                this.attribute = attribute;
            }

            /// <summary>
            /// 아이템 정보 출력
            /// </summary>
            public void PrintInfo()
            {
                Console.WriteLine($"\t{name}");
                Console.WriteLine($"\t가격 : {price}G");
                Console.WriteLine($"\t설명 : {description}");
                Console.WriteLine($"\t{attribute} {(atrValue >= 0 ? "상승" : "감소")}  : {atrValue}");
            }


        }


        //속성 열거형
        public enum Attribute
        {
            공격력,
            방어력,
            체력,
            골드
        }


        //플레이어 구조체
        public struct Player
        {
            public int gold;
            public Item[] inventory;
            public int itemCnt;
            public int attack;
            public int health;
            public int defense;

            public const int DEFAULT_ATTACK = 15;
            public const int DEFAULT_HEALTH = 100;
            public const int DEFAULT_DEFENSE = 5;


            /// <summary>
            /// 플레이어 생성자. 기본 속성을 초기화한다.
            /// </summary>
            public Player()
            {
                gold = 5000;
                inventory = new Item[6];
                itemCnt = 0;
                attack = DEFAULT_ATTACK;
                health = DEFAULT_HEALTH;
                defense = DEFAULT_DEFENSE;

            }

            /// <summary>
            /// 플레이어 골드 보유량, 공격력, 방어력, 체력 속성을 출력한다.
            /// </summary>
            public void PrintInfo()
            {
                Console.WriteLine($"플레이어 {Attribute.골드,3} 보유량 : {this.gold:N0}G"); //숫자 포맷 : N0 (천 단위 쉼표 + 소수점 없음)
                Console.WriteLine($"플레이어 {Attribute.공격력,3} 상승량 : {attack - DEFAULT_ATTACK}");
                Console.WriteLine($"플레이어 {Attribute.방어력,3} 상승량 : {defense - DEFAULT_DEFENSE}");
                Console.WriteLine($"플레이어 {Attribute.체력,3} 상승량 : {health - DEFAULT_HEALTH}");
            }


            /// <summary>
            /// 인벤토리에 보유하고 있는 아이템 목록을 출력한다. 빈 칸은 출력하지 않는다.
            /// </summary>
            public void PrintInventory()
            {
                if (itemCnt == 0)
                {
                    Console.WriteLine("인벤토리가 비어있습니다.");
                    return;
                }

                for (int i = 0, idx = 1; i < inventory.Length; i++)
                {
                    if (inventory[i].name != null)
                    {
                        Console.Write($"{idx++}.");
                        inventory[i].PrintInfo();
                        Console.WriteLine();
                    }
                }
            }

            /// <summary>
            /// 아이템 획득. 아이템을 인벤토리에 추가하고 스탯을 증가시킨다. 스탯 변경에 따른 문구가 출력된다.
            /// </summary>
            /// <param name="item"></param>
            public void GetItem(Item item)
            {
                //아이템 총 개수 증가
                itemCnt++;

                //인벤토리에 아이템 추가
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i].name == null)
                    {
                        inventory[i] = item;
                        break;
                    }
                }

                //스탯 증가
                switch (item.attribute)
                {
                    case Attribute.공격력:
                        attack += item.atrValue;
                        break;
                    case Attribute.방어력:
                        defense += item.atrValue;
                        break;
                    case Attribute.체력:
                        health += item.atrValue;
                        break;

                }

                Console.WriteLine($"플레이어의 {item.attribute}이 {item.atrValue} 상승하여 {GetAttributeValue(item.attribute)}이 됩니다.");
            }

            public void RemoveItem(Item item)
            {
                //아이템 개수 감소
                itemCnt--;
                //아이템 효과 해제

                switch (item.attribute)
                {
                    case Attribute.공격력:
                        attack -= item.atrValue;
                        break;
                    case Attribute.방어력:
                        defense -= item.atrValue;
                        break;
                    case Attribute.체력:
                        health -= item.atrValue;
                        break;

                }

                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i].name == item.name)
                    {
                        ClearInventorySlot(i);
                        break;
                    }
                }



                Console.WriteLine($"플레이어의 {item.attribute}이 {item.atrValue} 감소하여 {GetAttributeValue(item.attribute)}이 됩니다.");
            }

            public void ClearInventorySlot(int slotIdx)
            {
                inventory[slotIdx] = new Item();
            }


            /// <summary>
            /// Attrubute 타입에 해당하는 플레이어의 속성 값을 반환한다.
            /// </summary>
            /// <param name="attribute">Attribute 타입</param>
            /// <returns></returns>
            public int GetAttributeValue(Attribute attribute)
            {
                switch (attribute)
                {
                    case Attribute.공격력:
                        return attack;
                    case Attribute.방어력:
                        return defense;
                    case Attribute.체력:
                        return health;
                    case Attribute.골드:
                        return gold;
                    default:
                        return 0;
                }
            }


            /// <summary>
            /// 보유하고 있는 골드 업데이트. 플레이어의 골드 보유량이 감소/증가하고 안내 문구가 출력된다.
            /// </summary>
            /// <param name="offset">골드 변화량</param>
            public void UpdateGold(int offset)
            {
                gold += offset;
                Console.WriteLine($"보유한 골드가 {(Math.Abs(offset)):N0}G {((offset >= 0) ? "상승" : "감소")}하여 {gold:N0}가 됩니다.");

            }



        }

        public static void StoreGame()
        {
            //상점 아이템
            Item[] store =
            {
                new Item("롱소드", "기본적인 검이다.", 450, 15, Attribute.공격력),
                new Item("천갑옷", "얇은 갑옷이다.",450,10,Attribute.방어력),
                new Item("여신의 눈물", "희미하게 푸른빛을 품고 있는 보석이다.", 800, 300, Attribute.체력),
                new Item("완전 비싼 아이템", "골드 부족한 경우를 테스트 하기 위해 추가한 아이템이다.", 100000000, 10000000, Attribute.체력)

            };

            Player player = new Player();





            int menu = 0;

            Console.WriteLine("**************************************");
            Console.WriteLine("************ 아이템 상점 *************");
            Console.WriteLine("**************************************");
            Console.WriteLine();


            while (menu != 4)
            {
                PrintMenu(out menu);
                switch (menu)
                {
                    case 1:
                        BuyItem(store, ref player);
                        break;
                    case 2:
                        SellItem(ref player);
                        break;
                    case 3:
                        ShowInventory(player);
                        break;
                    case 4:
                        Console.WriteLine("게임을 종료합니다.");
                        break;
                }

                Console.WriteLine();
            }


        }


        /// <summary>
        /// 메뉴 출력
        /// </summary>
        /// <param name="menu">사용자가 입력한 메뉴 번호(1~4 사이)</param>
        public static void PrintMenu(out int menu)
        {
            Console.WriteLine("======= 상점 메뉴 =======");
            Console.WriteLine("1. 아이템 구매\n2. 아이템 판매\n3. 아이템 확인\n4. 종료");
            Console.Write("메뉴를 선택하세요 : ");

            while (!int.TryParse(Console.ReadLine(), out menu) && menu < 1 && menu > 4)
            {
                Console.Write("메뉴를 선택하세요 : ");
            }

            Console.WriteLine();
        }


        /// <summary>
        /// 아이템 구매
        /// </summary>
        /// <param name="store">상점</param>
        /// <param name="player">플레이어</param>
        public static void BuyItem(Item[] store, ref Player player)
        {
            //플레이어가 선택한 아이템 번호
            int itemNum = 0;


            //상점이 소유하고 있는 아이템 목록이 제공된다.
            Console.WriteLine("======= 아이템 구매 =======");
            //플레이어가 보유한 골드 출력
            Console.WriteLine($"보유한 골드 : {player.gold:N0}G");

            Console.WriteLine();
            for (int i = 0; i < store.Length; i++)
            {
                Console.Write($"{i + 1}.");
                store[i].PrintInfo();
                Console.WriteLine();
            }

            //구매하고자 하는 아이템 선택

            do
            {
                Console.Write("구매할 아이템을 선택하세요 (취소 0) : ");

            } while (!int.TryParse(Console.ReadLine(), out itemNum) || itemNum < 0 || itemNum > store.Length);


            //구매처리
            if (itemNum == 0)
            {
                Console.WriteLine("구매를 취소합니다.");
                Console.WriteLine();
                return;
            }

            //돈 부족시 구매 안됨
            if (store[itemNum - 1].price > player.gold)
            {
                Console.WriteLine("골드가 부족합니다.");
                Console.WriteLine();
                return;
            }

            //인벤토리가 꽉 찬 경우 구매 안됨
            if (player.itemCnt == 6)
            {
                Console.WriteLine("인벤토리가 꽉 찼습니다. 아이템을 구매할 수 없습니다.");
                Console.WriteLine();
                return;
            }


            //구매 결과 및 플레이어 스탯 변화 출력
            Console.WriteLine($"{store[itemNum - 1].name}을/를 구매합니다.");
            player.GetItem(store[itemNum - 1]);
            player.UpdateGold(-(store[itemNum - 1].price));
            Console.WriteLine();

            return;

        }



        public static void SellItem(ref Player player)
        {
            int itemNum = -1;


            Console.WriteLine("======= 아이템 판매 =======");
            Console.WriteLine();

            player.PrintInventory();
            Console.WriteLine();

            if (player.itemCnt == 0)
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
                return;
            }


            while (true)
            {
                Console.Write("판매할 아이템을 선택하세요 (취소 0) : ");

                if (!int.TryParse(Console.ReadLine(), out itemNum) || itemNum < 0 || itemNum > player.inventory.Length)
                {
                    continue;
                }


                //판매 취소
                if (itemNum == 0)
                {
                    return;
                }



                //판매 처리
                Console.WriteLine($"{player.inventory[itemNum - 1].name}을/를 판매합니다.");

                int price = player.inventory[itemNum - 1].price;

                //아이템 효과 해제 및 인벤토리에서 삭제
                player.RemoveItem(player.inventory[itemNum - 1]);


                //골드 처리
                player.UpdateGold(price);

                break;


            }


        }



        /// <summary>
        /// 아이템 확인
        /// </summary>
        /// <param name="player">플레이어</param>
        public static void ShowInventory(Player player)
        {
            Console.WriteLine("======= 아이템 확인 =======");
            player.PrintInfo();

            Console.WriteLine();
            player.PrintInventory();

            Console.Write("계속하려면 아무키나 입력하세요 : ");
            Console.ReadLine();



        }


    }
}
