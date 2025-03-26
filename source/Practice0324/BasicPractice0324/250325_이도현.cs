using System.Threading.Channels;

namespace BasicPractice0324;

class Program
{
    static void Main(string[] args)
    {
        int menu;
        Monster[] monsterList = new Monster[10];
        
        //몬스터 생성
        monsterList[0] = new Monster("모부기", 10);
        monsterList[1] = new Monster("불꽃숭이", 12);
        monsterList[2] = new Monster("팽도리", 8);
        monsterList[3] = new Monster("디아루가", 100);
        monsterList[4] = new Monster("펄기아", 96);
        monsterList[5] = new Monster("기라티나", 102);
        monsterList[6] = new Monster("유크시", 70);
        monsterList[7] = new Monster("엠라이트", 70);
        monsterList[8] = new Monster("아그놈", 70);
        monsterList[9] = new Monster("피카츄", 44);
        

        Console.Write("플레이어의 이름을 입력해주세요. : ");
        string playerName = Console.ReadLine();
        Trainer trainer = new Trainer(playerName);
        Console.WriteLine();

        Console.WriteLine($"환영합니다! {trainer.Name}님.");
        Console.WriteLine();
        //출력
        while (true)
        {
            PrintMenu();
            Console.Write("메뉴를 선택하세요 : ");
            if (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 4)
            {
                Console.WriteLine();
               continue;
            }
            
            Console.WriteLine();
            switch (menu)
            {
                case 4:
                    Console.WriteLine("종료합니다.");
                    return;
                case 1:
                    AddMonster(trainer,monsterList);
                    break;
                case 2:
                    RemoveMonster(trainer,monsterList);
                    break;
                case 3:
                    trainer.PrintAll();
                    break;
            
            }
        }

        
        
        
        
        
    }
    
    #region ExecuteMethod
    static void PrintMenu()
    {
        Console.WriteLine("----------메뉴-----------");
        Console.WriteLine("1. 몬스터 추가하기");
        Console.WriteLine("2. 몬스터 삭제하기");
        Console.WriteLine("3. 보유하고 있는 몬스터 보기");
        Console.WriteLine("4. 종료");
        Console.WriteLine("--------------------------");
        
    }

    static void PrintMonsterList(Monster[] monsterList)
    {
        Console.WriteLine("---------- 몬스터 리스트 ---------");
        foreach (Monster monster in monsterList)
        {
            monster.Print();
            Console.WriteLine();
        }
        
        Console.WriteLine("-------------------------");
    }

    static Monster GetMonster(string monsterName, Monster[] monsterList)
    {
        for (int i = 0; i < monsterList.Length; i++)
        {
            if (monsterList[i].Name == monsterName)
            {
                return monsterList[i];
            }
        }
        return null;
    }

    static void AddMonster(Trainer t, Monster[] monsterList)
    {
        string monsterName;
        Monster monster;
        
        PrintMonsterList(monsterList);
        Console.Write("추가할 몬스터의 이름을 입력하세요 : ");
        
        monsterName = Console.ReadLine();
        monster = GetMonster(monsterName, monsterList);
        if (monster == null)
        {
            Console.WriteLine("잘못된 이름의 몬스터입니다. 몬스터를 추가할 수 없습니다.");
            Console.WriteLine();
        }
        else
        {
            t.Add(monster);
        }
    }
    
    

    static void RemoveMonster(Trainer t, Monster[] monsterList)
    {
        string monsterName;
        Monster monster=null;
        
        t.PrintAll();

        if (t.Cnt > 0)
        {
            Console.Write("제외할 몬스터의 이름을 입력하세요 : ");
            monsterName = Console.ReadLine();
            monster = GetMonster(monsterName, monsterList);

        }
        
        t.Remove(monster);
    }
    #endregion
}



class Trainer
{
    private string name; //이름
    public string Name => name;
    private Monster[] monsters; //몬스터 배열
    private int cnt;
    public int Cnt => cnt;
    
    //생성자
    public Trainer(string name)
    {
        this.name = name;
        monsters = new Monster[6];
        cnt = 0;
    }
    
    //add
    public void Add(Monster monster)
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i] == null)
            {
                monsters[i] = monster;
                cnt++;
                Console.WriteLine($"새로운 몬스터가 파티에 합류했습니다!");
                Console.WriteLine();
                return;
            }

           
        }
        Console.WriteLine("파티가 가득 찼습니다. 더 이상 데리고 다닐 수 없습니다.");
        Console.WriteLine();
    }
    //remove
    public void Remove(Monster monster)
    {
        if (cnt == 0)
        {
            Console.WriteLine("보유하고 있는 몬스터가 없습니다.");
            Console.WriteLine();
            return;
        }
        
        
        if (monster!=null)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i].Name == monster.Name)
                {
                    monsters[i] = null;
                    cnt--;
                    Console.WriteLine($"몬스터를 파티에서 제외했습니다.");
                    Console.WriteLine();
                    return;
                }

           
            }
        }
       
        
        Console.WriteLine("해당 몬스터는 파티에 없습니다.");
        Console.WriteLine();
    }
    
    //printall
    public void PrintAll()
    {
        Console.WriteLine($"[ 현재 파티 몬스터: {cnt}마리 ]");
        Console.WriteLine("------------------------------------");
        for (int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i] != null)
            {
                monsters[i].Print();
                Console.WriteLine();
                
            }
        }
        Console.WriteLine("------------------------------------");
        Console.WriteLine();
    }
}

class Monster
{
    private string name; //이름
    private int level; //레벨

    public string Name => name;

    //생성자
    public Monster(string name, int level)
    {
        this.name = name;
        this.level = level;
    }

    //Print
    public void Print()
    {
        Console.WriteLine($"이름 : {name}");
        Console.WriteLine($"레벨 : {level}");
    }


}