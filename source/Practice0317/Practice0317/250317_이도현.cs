namespace Practice0317;

class Program
{
    struct Item
    {
        public string itemName;
        public string itemID;

        public void Use()
        {
            Console.WriteLine($"{this.itemID}/{this.itemName} 사용!");
            this.itemID = "";
            this.itemName = "";
        }
    }

    struct Inventory
    {
        //생성자 : 인벤토리 사이즈 입력받아 배열의 크기를 지정
        public Inventory(int inventorySize) 
        {
            this.inventorySize = inventorySize; //인벤토리 사이즈로 저장
            //사이즈 크기의 배열 생성
            this.itemArray = new Item[this.inventorySize];
            this.cnt = 0;

            Console.WriteLine("인벤토리 생성 완료!");
        }
        
        public Item[] itemArray; //아이템 배열
        public int inventorySize; //인벤토리 사이즈
        public int cnt;

        
        /// <summary>
        /// 아이템 추가. 빈 자리를 찾아 입력받은 아이템 추가
        /// </summary>
        /// <param name="item">아이템</param>
        public void AddItem(Item newItem)
        {
            int i = 0;
            for (; i < inventorySize; i++)
            {
                if (string.IsNullOrEmpty(itemArray[i].itemID))
                {
                    itemArray[i].itemID = newItem.itemID;
                    itemArray[i].itemName = newItem.itemName;

                    this.cnt++;

                    Console.WriteLine("아이템 추가 완료!");
                    return;
                }
            }

        }
        
        /// <summary>
        /// 아이템 사용 기능1 : 정수를 매개변수로 입력받아 해당 순서에 있는 아이템을 사용한다.
        /// </summary>
        /// <param name="idx">인벤토리 내 아이템의 인덱스</param>
        public void UseItem(int idx)
        {
            if (idx < 0 || idx >= inventorySize)
            {
                Console.WriteLine("잘못된 인덱스입니다. 인벤토리 범위를 벗어납니다.");
                return;
            }
            
            ref Item item = ref itemArray[idx]; // 원본 참조 가져오기!!
            if(string.IsNullOrEmpty(item.itemID))
                Console.WriteLine("사용 가능한 아이템이 없습니다.");
            else
            {
                item.Use();
                this.cnt--;
            }
        }
        // public void UseItem(int idx)
        // {
        //     if (idx < 0 || idx >= inventorySize)
        //     {
        //         Console.WriteLine("잘못된 인덱스입니다. 인벤토리 범위를 벗어납니다.");
        //         return;
        //     }
        //
        //     if(string.IsNullOrEmpty(itemArray[idx].itemID))
        //         Console.WriteLine("사용 가능한 아이템이 없습니다.");
        //     else
        //     {
        //         // itemArray[idx].itemID = "";
        //         // itemArray[idx].itemName = "";
        //         itemArray[idx].Use();
        //         this.cnt--;
        //     }
        // }

        /// <summary>
        /// 아이템 사용 기능2 : 이름을 매개변수로 입력받아 인벤토리 내 아이템 사용
        /// </summary>
        /// <param name="itemName"></param>
        public void UseItem(string itemName)
        {
            
            for (int i = 0; i < inventorySize; i++)
            {
                ref Item item = ref itemArray[i]; // 원본 참조 가져오기!!
                if (string.Equals(itemName, item.itemName))
                {
                    item.Use(); // 이제 원본 수정됨!
                    cnt--;
                    return;
                }
            }

            Console.WriteLine("사용 가능한 아이템이 없습니다.");
            
        }

        /// <summary>
        /// 인벤토리 정보 출력. 인벤토리에 들어있는 아이템 전부 출력
        /// </summary>
        public void PrintInventoryInfo()
        {
            Console.WriteLine("------------------<인벤토리 정보>------------------");

            for (int i = 0; i < inventorySize; i++)
            {
                Console.WriteLine($"[{i}] {itemArray[i].itemID}     {itemArray[i].itemName}");
            }
        }

        
        
    }
    
    static void Main(string[] args)
    {
        int size;
        int menu;
        Console.Write("------------------<인벤토리 생성>------------------\n원하는 인벤토리 사이즈를 입력하세요 : ");
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
        {
            Console.Write("0보다 큰 숫자만 입력해주세요!! : ");
        }

        Inventory inventory = new Inventory(size);

        Console.WriteLine("");
        
        while (true)
        {
            //메뉴 선택
            PrintMenu();
            while (!int.TryParse(Console.ReadLine(), out menu) || (menu < 0 || menu > 4))
            {
                Console.Write("원하는 메뉴를 선택해주세요(0~4 사이 숫자만 가능): ");
            }

            Console.WriteLine();

            //선택한 메뉴에 따른 기능 수행
            switch (menu)
            {
                case 0:
                    ExitMenu();
                    return;
                case 1:
                    if(inventory.cnt<inventory.inventorySize)
                        inventory.AddItem(AddItem());
                    else
                        Console.WriteLine("인벤토리가 가득 찼습니다. 더 이상 아이템을 추가할 수 없습니다.");
                    break;
                case 2:
                    inventory.UseItem(GetItemIndex());
                    break;
                case 3:
                    inventory.UseItem(GetItemName());
                    break;
                case 4:
                    inventory.PrintInventoryInfo();
                    break;
            }

            Console.WriteLine();
        }
    }
    
    
    static void PrintMenu()
    {
        Console.WriteLine("------------------<메뉴>------------------\n0. 종료\n1. 아이템 추가\n2. 아이템 사용1(아이템 위치)\n3. 아이템 사용2(아이템 이름)\n4. 인벤토리 정보 출력");
        Console.WriteLine("------------------------------------------");
        Console.Write("원하는 메뉴를 선택해주세요(0~4 사이 숫자만 가능): ");
    }


    static void ExitMenu()
    {
        Console.WriteLine("프로그램을 종료합니다.");
    }

    static Item AddItem()
    {
        Item newItem;
        
        Console.WriteLine("------------------<아이템 추가>------------------");
        do
        {
            Console.Write("추가할 아이템의 ID를 입력하세요(1자 이상) : ");
            newItem.itemID = Console.ReadLine();
        } while (string.IsNullOrEmpty(newItem.itemID));
        do
        {
            Console.Write("추가할 아이템의 이름 입력하세요(1자 이상) : ");
            newItem.itemName = Console.ReadLine();
        } while (string.IsNullOrEmpty(newItem.itemName));
        
        return newItem;
    }

    static int GetItemIndex()
    {
        int idx;
        do
        {
            Console.Write("사용할 아이템 위치(인덱스)를 입력하세요.(0 이상의 숫자) : ");
        } while (!int.TryParse(Console.ReadLine(), out idx));
        
        return idx;
        
    }

    static string GetItemName()
    {
        string name;
        do
        {
            Console.Write("사용할 아이템의 이름을 입력하세요.(1자 이상): ");
            name = Console.ReadLine();
        } while (string.IsNullOrEmpty(name));

        return name;
    }
}