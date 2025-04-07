namespace Practice0401_Test3;

public class Shop
{
    public Inventory Inventory { get; private set; }

    public Shop(int capacity, params Item[] items)
    {
        Inventory = new Inventory(capacity);

        foreach (var item in items)
        {
            Inventory.AddItem(item);
        }
    }


    public void PrintMenu()
    {
        Console.WriteLine("========== 상점 메뉴 ==========");
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("2. 아이템 판매");
        Console.WriteLine("3. 아이템 확인");
    }

    public int MenuChoice()
    {
        int choice;
        while (true)
        {
            Console.Write("메뉴를 선택하세요 : ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
            {
                Console.WriteLine();
                return choice;
            }

        }
    }


    public void BuyItem(Player player)
    {
        while (true)
        {
            Console.WriteLine("========== 아이템 구매 ==========");
            player.PrintGold();
            Console.WriteLine();
            Inventory.PrintAllItems();

            while (true)
            {
                int choice;
                Console.Write("구매할 아이템을 선택하세요 (뒤로가기 0) : ");

                //범위 내의 숫자 입력시
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice <= Inventory.Count)
                {
                    Console.WriteLine();

                    if (choice == 0)
                    {
                        //뒤로가기
                        return;
                    }

                    Item item = Inventory.GetItem(choice - 1);
                    //구매 가능 여부 확인
                    if (item == null)
                    {
                        throw new Exception("잘못된 인덱스입니다. 아이템을 찾을 수 없습니다.");
                    }

                    player.TryBuyItem(item);
                    break;
                }
            }

        }
       
    }
    
}