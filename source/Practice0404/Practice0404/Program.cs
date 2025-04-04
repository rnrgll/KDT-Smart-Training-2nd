namespace Practice0404;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("======= 팩토리 패턴 실습 ========");
        List<Weapon> weapons = new List<Weapon>(10);
        weapons.Add(WeaponFactory.Create("철검", Rarity.Legendary));
        weapons.Add(WeaponFactory.Create("철검", Rarity.Normal));
        weapons.Add(WeaponFactory.Create("쇠도끼", Rarity.Rare));
        weapons.Add(WeaponFactory.Create("쇠도끼", Rarity.Normal));
        weapons.Add(WeaponFactory.Create("나무창", Rarity.Normal));

        foreach (var w in weapons)
        {
            w.PrintInfo();
        }


        Console.WriteLine();


        Console.WriteLine("======= 빌더 패턴 실습 ========");
        List<Animal> animals = new List<Animal>(10);
        animals.Add(new AnimalBuilder()
            .SetName("소")
            .SetProduct("우유")
            .SetSound("음메")
            .SetFeedType("건초")
            .Build());

        animals.Add(new AnimalBuilder()
            .SetName("소")
            .SetProduct("우유")
            .SetSound("음메")
            .SetFeedType("건초")
            .SetIsRare(true)
            .Build());
        
        animals.Add(new AnimalBuilder()
            .SetName("양")
            .SetProduct("양털")
            .SetSound("메에에")
            .SetFeedType("건초")
            .Build());
        
        animals.Add(new AnimalBuilder()
            .SetName("닭")
            .SetProduct("달걀")
            .SetSound("꼬끼오")
            .SetFeedType("옥수수")
            .Build());
        
        
        animals.Add(new AnimalBuilder()
            .SetName("유니콘")
            .SetIsRare(true)
            .SetProduct("무지개 뿔")
            .SetSound("히히힝")
            .SetFeedType("마법 풀")
            .Build());



        foreach (var animal in animals)
        {
            animal.PrintInfo();
        }
        

    }
}