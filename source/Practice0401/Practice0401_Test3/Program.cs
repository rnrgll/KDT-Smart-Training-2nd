using System.Diagnostics;

namespace Practice0401_Test3;

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop(10);
        Player player = new Player();
        
        
        
        //프로그램
        bool isFinish = false;

        Start(shop);
        
        
        while (!isFinish)
        {
            shop.PrintMenu(); ;
            Result(shop.MenuChoice(),shop, player);
            
        }


    }


    //셋팅
    public static void Start(Shop shop)
    {
        //아이템 생성
        Item longSword = new Weapon(ActivationType.Passive, "롱소드", "기본적인 검이다", 400, 15);
        Item clothArmor = new Armor(ActivationType.Passive, "천갑옷", "얇은 갑옷이다", 500, 15);
        Item strangeCandy = new Accessory(ActivationType.Active, "이상한 사탕", "먹으면 신비한 효과를 일으킬 것 같다", 800,
            300, true);
       
        //상점 생섬 및 초기화
        shop.Inventory.AddItem(longSword);
        shop.Inventory.AddItem(clothArmor);
        shop.Inventory.AddItem(strangeCandy);
        
        //츨력
        Console.WriteLine("******************************");
        Console.WriteLine("*         아이템 상점        *");
        Console.WriteLine("******************************");

    }

    public static void Result(int choice, Shop shop, Player player)
    {
        switch(choice)
        {
            case 1:
                shop.BuyItem(player);
                break;
            case 2:
                player.SellItem();
                break;
            case 3:
                player.ShowItems();
                break;
        }
    }
    
    
    
    
    
}