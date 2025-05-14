namespace Practice0402;

class Program
{
    static void DFS(List<int>[] graph, int start)
    {
        //1. 각 노드가 방문됐는지를 기록할 배열 선언
        bool[] visited = new bool[graph.Length];
        
        //2. DFS에서 사용할 스택
        Stack<int> stack = new Stack<int>(graph.Length);
        
        //3. 시작 노드를 스택에 Push, 방문 표시
        stack.Push(start);
        // visited[start] = true;
        
        
        //4. 스택이 빌 때까지 반복한다.
        while (stack.Count > 0)
        {
            //5. 스택에서 노드를 꺼낸다. = 현재 탐색 중인 노드
            int current = stack.Pop();
            
            
            //출력
            if (!visited[current])
            {
                Console.Write(current);
                Console.Write(" ");
                
                visited[current] = true; //꺼낼때 방문처리하도록 한다
            }
         
           
            
            //6. current의 이웃 노드들을 역순으로 순회하며
            // (stack이 후입선출 구조이기 때문에 작은 번호부터 방문하려면 역순으로 넣어야 한다.)
            // for (int i = 0; i < graph[current].Count; i++)
            for(int i=graph[current].Count-1 ; i>=0 ; i--)
            {
                //7. 이웃 노드가 방문하지 않은 노드라면 스택에 push 후 visited 처리한다.
                if (visited[graph[current][i]] == false)
                {
                    stack.Push(graph[current][i]);
                    // visited[graph[current][i]] = true;
                }
            }
        }
    }


    static void BFS(List<int>[] graph, int start)
    {
        //1. 각 노드가 방문됐는지를 기록할 배열 선언
        bool[] visited = new bool[graph.Length];
        
        //2. BFS에 사용할 큐 생성
        Queue<int> queue = new Queue<int>(graph.Length);
        
        
        //3. 시작 노드를 큐에 추가하고 방문 처리
        queue.Enqueue(start);
        visited[start] = true;

        
        //4. 큐가 빌 때까지 반복
        while (queue.Count > 0)
        {
            //5. 큐에서 노드를 꺼냄 = 현재 탐색 중인 노드
            int current = queue.Dequeue();
            
            //출력
            Console.Write(current);
            Console.Write(" ");
            
            //6. 현재 노드의 이웃 노드들을 모두 확인하여
            for (int i = 0; i < graph[current].Count; i++)
            {
                //7. 방문하지 않은 노드라면 큐에 추가하고 방문 처리
                if (visited[graph[current][i]] == false)
                {
                    queue.Enqueue(graph[current][i]);
                    visited[graph[current][i]] = true;
                }
            }
        }

    }
    
    
    static void Main(string[] args)
    {
        int n; //정점의 개수
        int m; //간선의 개수
        int v; //탐색을 시작할 정점의 번호
        
        //입력
        string[] inputs = Console.ReadLine().Split(' ');
        n = int.Parse(inputs[0]);
        m = int.Parse(inputs[1]);
        v = int.Parse(inputs[2]);
        
        //인접리스트 그래프 만들기
        List<int>[] graph = new List<int>[n+1]; //노드가 1부터 시작하므로 조정
        //각 배열의 요소 초기화해야함(그래야 NullReferenceException이 발생하지 않음)
        for (int i = 1; i < n+1; i++)
        {
            graph[i] = new List<int>(m);
        }

        for (int i = 0; i < m; i++)
        {
            string[] edges = Console.ReadLine().Split(' ');
            int start = int.Parse(edges[0]);
            int end = int.Parse(edges[1]);
            
            //양방향 그래프
            graph[start].Add(end);
            graph[end].Add(start);
        }
        for (int i = 1; i <= n; i++)
        {
            graph[i].Sort();
        }

        //출력
        DFS(graph, v);
        Console.WriteLine();
        BFS(graph, v);

    }

   
    
    

}