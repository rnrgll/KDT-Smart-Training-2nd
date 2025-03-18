namespace ConsolePractice1;

class MazeGame
{
    struct Position
    {
        public int x;
        public int y;
    }

    static void Main(string[] args)
    {
        bool gameOver = false;

        Position playerPos;
        Position goalPos;
        bool[,] map;

        Start(out playerPos, out goalPos, out map);
        while (gameOver == false)
        {
            Render(playerPos, goalPos, map);
            ConsoleKey key = Input();
            Update(key, ref playerPos, goalPos, map, ref gameOver);
        }

        End();
    }


    static void Start(out Position playerPos, out Position goalPos, out bool[,] map)
    {
        //게임 설정
        Console.CursorVisible = false; //커서 깜박거림 안보이게 설정

        //플레이어 초기 위치 설정하기
        playerPos.x = 1;
        playerPos.y = 1;

        //목적지 위치 설정하기
        goalPos.x = 13;
        goalPos.y = 8;


        //맵 설정하기
        map = new bool[10, 15]
        {
            /*0*/
            { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            /*1*/ { false, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
            /*2*/ { false, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
            /*3*/ { false, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
            /*4*/ { false, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
            /*5*/ { false, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
            /*6*/ { false, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
            /*7*/ { false, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
            /*8*/ { false, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
            /*9*/
            { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
        };
        
        
        ShowTitle();
    }


    static void ShowTitle()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("레전드 미로 찾기");
        Console.WriteLine("----------------------");
        Console.WriteLine();
        Console.WriteLine("아무키나 눌러서 시작하세요.");


        Console.ReadKey(true); //누를때까지 기다리기
    }

    static void Render(Position playerPos, Position goalPos, bool[,] map)
    {
        //출력작업

        //콘솔 지우기
        Console.Clear();
        PrintMap(map);
        PrintPlayer(playerPos);
        PrintGoal(goalPos);
    }

    //맵 출력
    static void PrintMap(bool[,] map)
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (!map[y, x])
                {
                    Console.Write('#');
                }
                else
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine();
        }
    }

    static void PrintPlayer(Position playerPos)
    {
        //플레이어 위치로 커서 옮기기
        Console.SetCursorPosition(playerPos.x, playerPos.y);
        //플레이어 출력
        Console.Write('P');
    }

    static void PrintGoal(Position goalPos)
    {
        Console.SetCursorPosition(goalPos.x, goalPos.y);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write('G');

        Console.ResetColor(); //색깔 초기화
    }

    static ConsoleKey Input()
    {
        //입력작업
        return Console.ReadKey(true).Key;
    }

    static void Update(ConsoleKey key, ref Position playerPos, Position goalPos, bool[,] map, ref bool gameOver)
    {
        //처리작업

        //이동 수행
        Move(key, ref playerPos, map);

        //골에 도달했는지 확인
        gameOver = CheckGameClear(playerPos, goalPos);

    }
    static void Move(ConsoleKey key, ref Position playerPos, bool[,]map)
    {
        switch (key)
        {
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                if (map[playerPos.y, playerPos.x - 1] == true)
                    playerPos.x--;
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                if (map[playerPos.y, playerPos.x + 1] == true)
                    playerPos.x++;
                break;
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                if (map[playerPos.y - 1, playerPos.x] == true)
                    playerPos.y--; //콘솔에서는 위로 갈수록 y값이 감소한다. (1번째 줄, 2번째 줄... 이렇게 되므로)
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                if (map[playerPos.y + 1, playerPos.x] == true)
                    playerPos.y++;
                break;
        }
    }

    static bool CheckGameClear(Position playerPos, Position goalPos)
    {
        //플레이어가 골 위치에 도달했을 때 게임은 클리어 되었다고 판정
        //플레이어의 x 위치 == 골 x 위치 && 플레이어 y 위치 == 골 y 위치
        return (playerPos.x == goalPos.x && playerPos.y == goalPos.y);
    }

static void End()
    {
        // 종료 작업
        Console.Clear();
        Console.WriteLine("축하합니다! 미로 찾기에 성공하셨습니다!");
    }
}