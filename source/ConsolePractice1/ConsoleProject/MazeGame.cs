namespace ConsoleProject
{
    /*
    - 플레이어 구조체 ✓
    - 플레이어 이동 ✓
        - 벽 ✓
        - 점 획득 ✓
        - 목표 지점 도달 ✓
    - 맵 구현 ✓
    - 초기화 ✓
        - 플레이어 초기화 ✓
        - 스테이지 초기화 ✓
    - 종료 조건 ✓
    - 게임 ui ✓
       시작화면 ✓
       게임 방법 ✓
       게임 화면 ✓
       게임 종료 ✓
    - 레벨 추가 ✓
    - 함정 : 밟으면 랜덤한 위치로 이동
    */

    //게임 플레이 방법
    //1. 상하좌우 키로 이동
    //2. 미로에 흩뿌려진 점을 먹으며 목표 지점까지 이동하자!
    //3. 점을 먹으면 포인트가 증가!
    //4. 점 : 'd', 목표 지점 : 'G'
    //5. 함정 밟으면 랜덤한 위치로 이동!



    struct Position
    {
        public int x;
        public int y;
    }

    struct Player
    {
        public Position pos;
        public int point;
        public bool isTrapped; //함정 상태 여부

    }

    
    struct Map
    {
        public char[,] mapArray;
        public Position startPos;

        public Map(char[,] mapArray, int startX, int startY)
        {
            this.mapArray = mapArray;
            startPos.x = startX;
            startPos.y = startY;
        }
        
    }

    struct Stage
    {
        public int stageNum;
        public Map map;


        public Stage(int stageNum, char[,] map, int startX, int startY)
        {
            this.stageNum = stageNum;
            this.map = new Map(map,startX,startY);
        }
    }
    

    internal class MazeGame
    {
        static int moveCnt = 0;
        
        static void Main(string[] args)
        {

            #region Variables
            bool gameOver = false; //게임 오버 여부
            bool stageClear = false; //게임 클리어 여부

            Stage[] stages;
            int currentStageIdx = 0;

            Player player;
            #endregion


            Start(out player, out stages, ref currentStageIdx);


             while (!gameOver)
             {
                 InitStage(ref player, stages[currentStageIdx],out stageClear);
                 while (!stageClear)
                 {
                     Render(player,stages[currentStageIdx]);
                     ConsoleKey input = Input();
                     Update(input, ref player, stages, ref currentStageIdx, ref stageClear, ref gameOver);
                 }
                
             }


            End(player);

        }


        #region GameLoop

        #region Start

        static void Start(out Player player, out Stage[] stages, ref int currentStageIdx)
        {
            //게임 설정
            Console.CursorVisible = false; //커서 깜박임 제거
            
            //메뉴 선택값 초기화
            int menu = 0;
            
            //스테이지 생성 및 초기화
            stages = new Stage[3];
            MakeMap(ref stages);
            currentStageIdx = 0;
            
            //플레이어 초기화
            player = new Player();
            player.point = 0;
            
            
            while (true)
            {
                ShowStartScreen(menu);
                ConsoleKey key = Input();

                switch (key)
                {
                    case ConsoleKey.Enter:
                        if (menu == 1)
                        {
                            ShowGameRule();
                            break;
                        }
                        else
                        {
                            return;
                        }
                        
                    case ConsoleKey.W: case ConsoleKey.UpArrow:
                        menu--;
                        menu = Math.Max(menu, 0);
                        break;
                    case ConsoleKey.S: case ConsoleKey.DownArrow:
                        menu++;
                        menu = Math.Min(menu, 1);
                        break;
                    
                }

            }
        }

        static void ShowStartScreen(int menu)
        {
            Console.Clear();
            
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\t\t미로 찾기 게임");
            Console.WriteLine();

            Console.ForegroundColor = (menu == 0) ? ConsoleColor.Green : ConsoleColor.Gray;
            Console.WriteLine($"\t\t{(menu==0? "▶" : " ")} 게임 시작");
            Console.ForegroundColor = (menu == 1) ? ConsoleColor.Green : ConsoleColor.Gray;
            Console.WriteLine($"\t\t{(menu==1? "▶" : " ")} 게임 방법");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("\t   - Enter를 눌러 메뉴 선택 -");
            Console.WriteLine("---------------------------------------------------");
        }

        static void ShowGameRule()
        {
            Console.Clear();
            
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(" \t\t  게임 방법");
            Console.WriteLine();
            Console.WriteLine("  - 플레이어 이동 : wasd 혹은 상하좌우 키");
            Console.WriteLine("  - 미로에 흩뿌려진 점을 먹으며 목표 지점까지 이동하자!");
            Console.WriteLine("  - 점을 먹으면 포인트가 증가!");
            Console.WriteLine("  - 점 : '＊', 목표 지점 : '♥'");
            Console.WriteLine("  - 함정이 숨겨져 있다!\n    함정을 밟으면 랜덤한 위치로 순간이동!");
            Console.WriteLine();
            Console.WriteLine("\t    - Enter를 눌러 돌아가기 -");
            Console.WriteLine("---------------------------------------------------");
            
            while(Input()!=ConsoleKey.Enter){} //엔터키 누를 때까지 대기
        }


        static void MakeMap(ref Stage[] stages)
        {
            char[,] maze10x10 = new char[,]
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', 'S', 'd', 'd', 'T', '#', 'T', 'd', 'd', '#' },
                { '#', '#', '#', 'd', '#', '#', '#', '#', 'd', '#' },
                { '#', 'T', '#', 'd', '#', 'd', 'd', '#', 'T', '#' },
                { '#', 'd', 'd', 'd', '#', '#', 'd', '#', 'd', '#' },
                { '#', '#', '#', 'd', 'd', 'd', 'd', '#', 'd', '#' },
                { '#', 'd', 'd', 'd', '#', '#', '#', '#', 'd', '#' },
                { '#', 'd', '#', '#', '#', 'd', 'd', 'd', 'd', '#' },
                { '#', 'd', 'd', 'T', 'd', 'd', '#', 'G', '#', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            char[,] maze15x15 = new char[,]
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', 'S', 'd', 'd', 'd', 'd', '#', 'T', 'd', 'T', 'd', 'T', '#', '#', '#' },
                { '#', 'd', '#', '#', '#', 'd', '#', '#', '#', 'd', '#', 'd', 'd', 'd', '#' },
                { '#', 'd', 'd', 'd', '#', 'T', 'd', 'd', 'd', 'd', '#', 'd', '#', 'd', '#' },
                { '#', '#', '#', 'd', '#', '#', '#', '#', '#', 'd', '#', 'd', '#', 'd', '#' },
                { '#', 'd', 'd', 'd', 'd', 'T', 'T', '#', 'T', 'd', 'd', 'd', '#', 'd', '#' },
                { '#', 'd', '#', '#', '#', '#', '#', '#', '#', 'd', '#', '#', '#', 'd', '#' },
                { '#', 'd', 'd', 'T', '#', 'd', 'd', 'd', '#', 'd', 'd', 'd', '#', 'd', '#' },
                { '#', 'd', '#', '#', '#', 'd', '#', 'd', '#', 'd', '#', '#', '#', 'd', '#' },
                { '#', 'd', '#', 'd', 'd', 'd', '#', 'd', 'd', 'd', '#', 'T', 'd', 'd', '#' },
                { '#', 'd', '#', 'd', '#', '#', '#', '#', '#', '#', '#', 'd', '#', '#', '#' },
                { '#', 'd', '#', 'd', 'd', 'd', '#', 'T', 'd', 'd', '#', 'd', 'd', 'd', '#' },
                { '#', 'd', '#', '#', '#', 'd', '#', '#', '#', 'd', '#', 'd', '#', 'd', '#' },
                { '#', 'd', 'd', 'd', 'd', 'd', '#', 'd', 'T', 'd', 'd', 'T', '#', 'G', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            char[,] maze19x20 = new char[,]
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', 'S', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'T', 'd', 'd', 'd', 'd', 'd', 'd', 'T', 'd', '#' },
                { '#', 'd', '#', '#', '#', '#', '#', 'd', '#', '#', '#', '#', '#', '#', '#', 'd', '#', '#', 'd', '#' },
                { '#', 'd', '#', 'd', 'd', 'd', 'd', 'd', '#', 'd', 'd', 'T', 'd', 'd', '#', 'd', 'd', 'd', 'T', '#' },
                { '#', 'd', '#', 'd', '#', '#', '#', 'd', '#', '#', '#', '#', '#', 'T', '#', '#', '#', '#', '#', '#' },
                { '#', 'T', '#', 'd', '#', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'T', '#', '#' },
                { '#', 'T', '#', 'd', '#', '#', '#', '#', '#', 'd', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', 'd', '#', 'd', 'd', 'd', 'd', 'd', '#', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', '#', '#' },
                { '#', 'd', '#', '#', '#', '#', '#', 'd', '#', '#', '#', '#', '#', '#', '#', '#', '#', 'd', '#', '#' },
                { '#', 'T', 'd', 'd', 'd', 'd', '#', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', '#', 'd', 'd', '#' },
                { '#', '#', '#', '#', '#', 'd', '#', '#', '#', '#', '#', '#', '#', '#', '#', 'd', '#', 'd', 'T', '#' },
                { '#', 'T', 'd', 'd', '#', 'T', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', '#', 'T', 'd', '#' },
                { '#', '#', '#', 'd', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', 'd', '#', 'T', 'd', '#' },
                { '#', 'd', 'd', 'd', 'd', 'd', 'T', 'd', '#', 'T', 'd', 'd', 'd', 'd', 'd', 'd', '#', 'd', 'd', '#' },
                { '#', '#', '#', '#', '#', '#', '#', 'd', '#', '#', '#', '#', '#', '#', '#', '#', '#', 'd', 'T', '#' },
                { '#', 'd', 'T', 'd', 'd', 'T', 'd', 'd', '#', 'd', 'd', 'd', 'd', 'd', 'd', 'T', '#', 'd', '#', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', 'T', '#', '#', '#', '#', '#', '#', '#', 'd', '#', '#' },
                { '#', 'G', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', 'd', '#', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };




            stages[0] = new Stage(1, maze10x10, 1, 1);
            stages[1] = new Stage(2, maze15x15, 1, 1);
            stages[2] = new Stage(3, maze19x20, 1, 1);
        }


        #endregion

        static void InitStage(ref Player player, Stage stage, out bool stageClear)
        {
            
            //스테이지 클리어 플래그 초기화
            stageClear = false;
            
            //플레이어 위치 조정
            player.pos.x = stage.map.startPos.x;
            player.pos.y = stage.map.startPos.y;
            
        }
        
        #region Render
        static void Render(Player player, Stage stage)
        {
            //콘솔 지우기
            Console.Clear();
            
            
            PrintMap(stage.map.mapArray);
            PrintInfo(player, stage);
            PrintPlayer(player);
            
        }

        static void PrintMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == 'G')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("♥");
                    }
                    else if (map[y, x] == '#')
                    {
                        // Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("▒");
                    }
                    else if (map[y, x] == 'd'||map[y,x]=='T')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("d");
                        
                    }
                    else
                    {
                        Console.Write(map[y,x]);
                    }
                    
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
            
        }
        
        static void PrintInfo(Player player, Stage stage)
        {
            //스테이지 정보, 플레이어 포인트 표시
            Console.WriteLine("---------------------------------------------------");
            Console.Write($"스테이지 {stage.stageNum}   포인트 {player.point}P   이동 횟수 {moveCnt}회");
            
        }

        static void PrintPlayer(Player player)
        {
            Console.SetCursorPosition(player.pos.x, player.pos.y);
            if (player.isTrapped)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("○");  // 플레이어 표시
            }
            
            Console.ResetColor();
        }
        
        #endregion


        static ConsoleKey Input()
        {
            return Console.ReadKey(true).Key;
        }

        #region Update

        static void Update(ConsoleKey key ,ref Player player, Stage[] stages, ref int currentStageIdx, ref bool stageClear, ref bool gameOver)
        {
            //Move 플레이어 이동
            Move(key, ref player, ref stages[currentStageIdx], ref stageClear);
            
            
            //스테이지 클리어 시 스테이지 업데이트 및 플래그 초기화
            if (stageClear)
            {
                //현재 스테이지 인덱스 업데이트
                currentStageIdx++;
                
                //모든 스테이지를 끝낸 경우 게임 종료
                if (currentStageIdx >= stages.Length)
                    gameOver = true;
            }
        }

        static void Move(ConsoleKey key, ref Player player, ref Stage stage, ref bool stageClear)
        {
            char[,] mapArray = stage.map.mapArray;
            
            //1. 다음 위치 설정
            Position targetPos;
            targetPos.x = player.pos.x;
            targetPos.y = player.pos.y;

            switch (key)
            {
                case ConsoleKey.A: case ConsoleKey.LeftArrow:
                    targetPos.x--;
                    break;
                case ConsoleKey.D: case ConsoleKey.RightArrow:
                    targetPos.x++;
                    break;
                case ConsoleKey.W: case ConsoleKey.UpArrow:
                    targetPos.y--;
                    break;
                case ConsoleKey.S: case ConsoleKey.DownArrow:
                    targetPos.y++;
                    break;
            }
            
            
            //2. 다음 위치로 이동 가능한지 판단
            //벽이면 이동 불가,
            //점이면 이동 가능 & 포인트 5 획득 & 빈칸으로 갱신,
            //목표 지점이면 스테이지 클리어 처리 & 포인트 10 획득
            //트랩(함정)이면 함정 플래그 on & 플레이어 이동 및 원래 자리 빈칸으로 갱신 후 재랜더링 & 1초 대기 & 랜덤 위치로 이동시키기
            switch (mapArray[targetPos.y,targetPos.x])
            {
                case '#': //벽
                    //이동 불가
                    return;
                case 'd': 
                    player.point += 5;

                    //이동 횟수 증가
                    moveCnt++;

                    break;
                case 'G' ://점 또는 목표지점
                    stageClear = true;
                    player.point += 10;

                    //이동 횟수 증가
                    moveCnt++;

                    break;
                case 'T': 
                    //플레이어 상태를 트랩 밟은 상태로 변경
                    player.isTrapped = true;
                    //플레이엉 위치를 이동 시키기 & 플레이어 있던 곳 빈칸으로 처리
                    mapArray[player.pos.y, player.pos.x] = ' ';
                    player.pos = targetPos;

                    //이동 횟수 증가
                    moveCnt++;

                    //화면 갱신 (다시 그리기)
                    Render(player, stage);
                    
                    Thread.Sleep(1000); //1초 대기
                    
                    // //트랩 있던 곳 빈칸으로 변경 (아래에서 처리됨)
                    // mapArray[targetPos.y, targetPos.y] = ' ';
                    
                    //랜덤 위치 좌표 계산
                    targetPos = GetRandomEmptyPosition(mapArray);
                    break;
                    
            }
            //플레이어가 있던 자리 빈칸으로 갱신
            mapArray[player.pos.y, player.pos.x] = ' ';
            //플레이어 이동
            player.pos = targetPos;
            
            //플레이어 트랩 상태 복구
            player.isTrapped = false;
            
            ////이동 횟수 증가 => 트랩 구현 추가하면서 렌더링 갱신으로 시점 변경으로 인해 swich문 안으로 이동
            //moveCnt++;

        }

        static Position GetRandomEmptyPosition(char[,] map)
        {
            Position randomPos;

            Random random = new Random();
            while (true)
            {
                int y = random.Next(0, map.GetLength(0));
                int x = random.Next(0, map.GetLength(1));

                //빈칸, 점 지점이면 포지션 반환
                if (map[y, x] == 'd' || map[y, x] == ' ')
                {
                    randomPos.x = x;
                    randomPos.y = y;
                    return randomPos;
                }
            }

        }
        


        #endregion



        static void End(Player player) 
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t(◜o◝)︎✌︎ 게임 클리어 (◜o◝)︎✌︎");
            Console.WriteLine($"\t\t총 포인트 : {player.point}P");
            Console.WriteLine($"\t\t총 이동 횟수 : {moveCnt}회");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
        }

        #endregion
    }
    }