namespace Practice0313;

class Diamond
{
// - 출력할 다이아몬드 형태를 사용자로부터 입력 받은 후, 만약 짝수일경우 홀수를 다시 입력하라고 유저에게 무한 반복으로 요구한다.
// - 홀수가 입력되었을 경우, 다이아몬드 중간 부분이 유저의 입력과 같은 다이아몬드를 출력하는 프로그램 제작.
// - 실행 예시 :
    static void Main(string[] args)
    {
        int num; //다이아몬드 중간 줄 별 개수
        bool isInt = false;
        //입력
        Console.Write("출력할 다이아몬드 크기를 입력해주세요(홀수) : ");
        isInt = int.TryParse(Console.ReadLine(), out num);

        while (!isInt || num <= 1 || num % 2 == 0)
        {
            if (!isInt)
            {
                Console.WriteLine("올바르지 않은 입력입니다. 숫자를 입력해주세요!");
            }
            else if (num <= 0)
            {
                Console.WriteLine("0보다 큰 수를 입력해주세요!");
            }
            else if (num % 2 == 0)
            {
                Console.WriteLine("홀수를 입력해주세요!");

            }
            else if (num == 1)
            {
                Console.WriteLine("1보다 큰 홀수를 입력해주세요!");
            }

            Console.WriteLine();
            Console.Write("출력할 다이아몬드 크기를 입력해주세요(홀수) : ");
            isInt = int.TryParse(Console.ReadLine(), out num);

        }
        

        //위쪽 삼각형 (인덱스 0부터)
        //num/2 = 3을 기준으로 함
        //1(0)번째 줄 : 3-0 ~ 3+0 번째 위치는 별
        //2(1)번째 줄 : 3-1 ~ 3+1 번째 위치는 별
        //3(2)번째 줄 : 3-2 ~ 3+2 번째 위치는 별
        //4번째 줄 : 한 줄 쭉 출력
        //아래쪽 삼각형은 반대로
        
        
        //출력
        
        
        // 1번째 줄 : 4번 빈칸, 1번 별
        // 2번째 줄 : 3번 빈칸, 2번 별
        // ...
        // i번째 줄 : 5-i번 빈칸, i번 별 
        // 이런식으로 일반화 해서
        
        
        //위쪽 삼각형
        for (int i = 0; i < num / 2; i++)
        {
            for (int j = 0; j <= num / 2 + i; j++)
            {
                if (j < num / 2 - i) //(num/2 - i)번째 전까지는 빈칸 출력
                    Console.Write(" ");
                else                 //(num/2 - i)번째부터 (num/2+i)까지는 별 출력
                    Console.Write("*");
            }
            Console.WriteLine();
        }

        //가운데 줄
        for (int i = 0; i < num; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
        
        //아래쪽 삼각형
        for (int i = num / 2-1 ; i >= 0; i--)
        {
            for (int j = 0; j <= num / 2 + i; j++)
            {
                if (j < num / 2 - i) //(num/2 - i)번째 전까지는 빈칸 출력
                    Console.Write(" ");
                else                //(num/2 - i)번째부터 (num/2+i)까지는 별 출력
                    Console.Write("*");
            }

            Console.WriteLine();
        }
        
    }
    
}