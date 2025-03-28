namespace Practice0328;

class Josephus
{
    static void Main(string[] args)
    {
        //변수
        int n, k;
        List<int> answer = new List<int>();
        
        //입력
        string[] input = Console.ReadLine().Split(' ');
        n = int.Parse(input[0]);
        k = int.Parse(input[1]);
        
        //연산
        //1. 큐 생성, 1부터 n까지 큐에 추가
        Queue<int> queue = new();
        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(i+1);
        }
        
        //2. 큐에 담긴 사람이 0이 될때까지
        while (queue.Count > 0)
        {
            
            for (int i = 0; i < k - 1 && queue.Count>1; i++) //1명이면 반복문 거치지 않고 바로 제거
            {
                int temp = queue.Dequeue();
                queue.Enqueue(temp);
            }
            answer.Add(queue.Dequeue());
        }
        
        
            
        //출력
        Console.WriteLine("<"+string.Join(", ",answer)+">");
        
    }
    
}