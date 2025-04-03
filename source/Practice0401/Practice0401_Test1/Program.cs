namespace Practice0401;

class Program
{
    static void Main(string[] args)
    {

        #region Q1 - Swap 함수

        Console.WriteLine("=== Q1 - Swap 함수 제작 ===");
        Console.WriteLine();
        int iLeft = 10;
        int iRight = 20;
        Util.Swap(ref iLeft, ref iRight);
        Console.WriteLine("int 자료형을 사용한 Swap 함수");
        Console.WriteLine($"{iLeft}, {iRight}");

        Console.WriteLine();

        double dLeft = 3.5;
        double dRight = 8.8;
        Util.Swap(ref dLeft, ref dRight);
        Console.WriteLine("double 자료형을 사용한 Swap 함수");
        Console.WriteLine($"{dLeft}, {dRight}");

        Console.WriteLine();
        #endregion

        #region Q2 - 몬스터 클래스 구현
        Console.WriteLine("=== Q2 - 몬스터 클래스 구현 ===");
        Console.WriteLine();
        Monster[] monsters = new Monster[5];
        monsters[0] = new Pikachu();
        monsters[1] = new Charmander();
        monsters[2] = new Squirtle();
        monsters[3] = new Bulbasaur();
        monsters[4] = new Pikachu("털뭉치");


        foreach (Monster monster in monsters)
        {
            Console.WriteLine($"{monster.Name} 공격해!");
            monster.Attack();
            Console.WriteLine();
        }


        #endregion
        
        #region Q3 - 같은 숫자는 싫어

        Console.WriteLine("=== Q3 - 같은 숫자는 싫어 ===");
        Console.WriteLine();

        List<int> answer1 = new HateSameNum().Solution([1, 1, 3, 3, 0, 1, 1]);
        List<int> answer2 = new HateSameNum().Solution([4, 4, 4, 3, 3]);
        List<int> answer3 = new HateSameNum().Solution([2, 3, 8, 8, 6, 7, 7, 1, 4, 0, 6, 6, 6, 6, 0, 1, 1]);

        PrintList(answer1); //1, 3, 0, 1
        PrintList(answer2); //4, 3
        PrintList(answer3); // 2, 3, 8, 6, 7, 1, 4, 0, 6, 0, 1

        Console.WriteLine();

        #endregion
        
    }


    static void PrintList<T>(List<T> list)
    {
        
        Console.Write("[");
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);
            if(i!=list.Count-1) Console.Write(",");
            
        }
        Console.WriteLine("]");
    }
}