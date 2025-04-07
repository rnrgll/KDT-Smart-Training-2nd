namespace Practice0401_Test3;

public class Player
{
    private int gold;

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            if (value > 0)
            {
                gold = value;
            }
            else
            {
                gold = 0;
            }
        }
    }


    //기본 스탯
    private int baseHp;
    private int baseAttack;
    private int baseDefense;
    
    //스탯 상승량
    private int hpIncrease;
    private int attackIncrease;
    private int defenseIncrease;


    public int HpIncrease
    {
        get => hpIncrease;
        set => hpIncrease = Math.Max(-baseHp, value);
    }
    
    public int AttackIncrease
    {
        get => attackIncrease;
        set => attackIncrease = Math.Max(-baseAttack, value);
    }
    
    
    public int DefenseIncrease
    {
        get => defenseIncrease;
        set => defenseIncrease = Math.Max(-baseDefense, value);
    }
    
    
    //최종 스탯
    public int Hp => baseHp + hpIncrease;
    public int Attack => baseAttack + attackIncrease;
    public int Defense => baseDefense + defenseIncrease;
    
    
    //인벤토리
    private Inventory inventory;
    private const int INVENTORY_SIZE = 6;
    public Inventory Inventory => inventory;
    
    

    //생성자
    public Player()
    {
        //변수 초기화
        this.gold = 3000;
        baseHp = 100;
        baseAttack = 20;
        baseDefense = 5;
        
        hpIncrease = attackIncrease = defenseIncrease = 0;
        
        //인벤토리 생성
        inventory = new Inventory(INVENTORY_SIZE);
        
    }
    



    public void PrintInfo()
    {
        Console.WriteLine($"플레이어 골드  보유량 : {gold:N0}G");
        Console.WriteLine($"플레이어 공격력 상승량 : {AttackIncrease:N0}");
        Console.WriteLine($"플레이어 방어력 상승량 : {DefenseIncrease:N0}");
        Console.WriteLine($"플레이어 체력  상승량 : {HpIncrease:N0}");
        
    }

    public void PrintGold()
    {
        Console.WriteLine($"보유한 골드 : {gold:N0}G");
    }


    public void SellItem()
    {
        while (true)
        {
            Console.WriteLine("========== 아이템 판매 ==========");
            PrintGold();
            Console.WriteLine();
            if (Inventory.Count == 0)
            {
                Console.WriteLine("소유한 아이템이 없습니다.");
                Console.WriteLine();
                return;
            }
        
            Inventory.PrintAllItems();

            while (true)
            {
                int choice;
                Console.Write("판매할 아이템을 선택하세요 (뒤로가기 0) : ");

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

                    if (item == null)
                    {
                        throw new Exception("잘못된 인덱스입니다. 아이템을 찾을 수 없습니다.");
                    }
                
                    //아이템 판매 메시지 출력
                    Console.WriteLine($"{item.Name} 을/를 판매합니다.");
                    //아이템 판매
                    if (item.ActivationType == ActivationType.Passive)
                    {
                        item.RemoveEffect(this);
                    }
                    Inventory.RemoveItem(choice-1);
                
                    //골드 증가
                    Gold += item.Price;
                    Console.WriteLine($"보유한 골드가 {item.Price:N0}G 상승하여 {Gold:N0}G가 됩니다.");
                    Console.WriteLine();

                    break;

                }
            }
           
            
                
        }
    }

    public bool TryBuyItem(Item item)
    {
        if (Gold < item.Price)
        {
            Console.WriteLine("골드가 부족합니다.");
            Console.WriteLine();
            return false;
        }

        if (inventory.Count == INVENTORY_SIZE)
        {
            Console.WriteLine("인벤토리가 꽉 찼습니다.");
            Console.WriteLine();
            return false;
        }
        
        //아이템 구매 메시지 출력
        Console.WriteLine($"{item.Name} 을/를 구매합니다.");
        
        //아이템 추가
        if (item.ActivationType == ActivationType.Passive)
        {
            item.ApplyEffect(this);
        }
        Inventory.AddItem(item);
        
        //골드 감소 
        Gold -= item.Price;
        Console.WriteLine($"보유한 골드가 {item.Price:N0}G 감소하여 {Gold:N0}G가 됩니다.");
        Console.WriteLine();

        return true;
    }


    public void ShowItems()
    {
        while (true)
        {
            Console.WriteLine("========== 아이템 확인 ==========");
            PrintInfo();
            Console.WriteLine();
            
            if (Inventory.Count == 0)
            {
                Console.WriteLine("소유한 아이템이 없습니다.");
                Console.WriteLine();
                return;
            }
        
            Inventory.PrintAllItems();

            while (true)
            {

                int choice;
                Console.Write("사용할 아이템을 선택하세요 (뒤로가기 0) : ");

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

                    if (item == null)
                    {
                        throw new Exception("잘못된 인덱스입니다. 아이템을 찾을 수 없습니다.");
                    }

                    if (item.Use(this))
                    {
                        inventory.RemoveItem(choice - 1);
                    }

                    break;

                }
            }

        }
    }
}