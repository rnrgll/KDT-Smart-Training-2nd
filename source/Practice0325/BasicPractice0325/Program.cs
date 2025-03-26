namespace BasicPractice0325;

class Program
{
    static void Main(string[] args)
    {
        int menu;



        Console.Write("플레이어의 이름을 입력해주세요. : ");
        string playerName = Console.ReadLine();
        Trainer trainer = new Trainer(playerName);
        Console.WriteLine();

        Console.WriteLine($"환영합니다! {trainer.Name}님.");
        Console.WriteLine();

        while (true)
        {
            PrintMenu(ref trainer);
            Console.Write("메뉴 선택 : ");
            if (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 3)
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();
            switch (menu)
            {
                case 3:
                    Console.WriteLine("무사히 도망쳤다...!");
                    return;
                case 1:
                    if (trainer.fieldPokemon != null)
                        trainer.fieldPokemon.Attack();
                    else
                        Console.WriteLine("필드에 있는 포켓몬이 없습니다. 공격할 수 없습니다....");
                    break;
                case 2:
                    int idx;
                    trainer.Print();
                    while (true)
                    {
                        Console.Write("번호 입력 : ");
                        if (int.TryParse(Console.ReadLine(), out idx))
                            break;
                    }

                    Console.WriteLine();
                    trainer.Pick(idx-1);
                    break;
            }
        }


        static void PrintMenu(ref Trainer t)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"현재 필드에 있는 포켓몬 : {((t.fieldPokemon != null) ? (t.fieldPokemon.Name) : "없음")}");
            Console.WriteLine();
            Console.WriteLine("무엇을 하시겠습니까?");
            Console.WriteLine("1. 공격\t 2. 포켓몬 교체\t 3. 도망치기(종료)");
            Console.WriteLine("-------------------------------------");
        }
    }
}