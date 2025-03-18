namespace Practice0314;

class Fibonacci
{
    static void Main(string[] args)
    {
        int n;
        bool isNum;
        //입력 받기
        Console.Write("구할 피보나치 수의 순서를 입력하세요 (1 이상의 정수): ");        
        
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("0보다 큰 정수만 가능합니다!!");
            Console.Write("올바른 값을 입력하세요 (1 이상의 정수): ");            

        }

        Console.WriteLine($"{n}번째 피보나치 수는 {Fibo(n)}입니다.");
    }

    static long Fibo(int n)
    {
        if (n <= 2) return 1;

        long n1 = 1;
        long n2 = 1;
        long temp;

        for (int i = 3; i <= n; i++)
        {
            temp = n2;
            n2 = n1 + n2;
            n1 = temp;
        }
        return n2;


    }
}