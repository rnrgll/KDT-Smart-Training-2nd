namespace AdvancePractice0331;

public class StationLine : WeightedGraph<string>
{
    //생성자
    public StationLine(int capacity) : base(capacity) { }
    
    //간선추가(이름 기반)
    public bool AddEdge(string from, string to, double weight)
    {
        int fromIdx = GetNodeIndex(from);
        int toIdx = GetNodeIndex(to);

        return base.AddEdge(fromIdx, toIdx,weight);
    }

    //양방향 간선 추가(이름 기반)
    public bool AddEdgeCycle(string from, string to, double weight)
    {
        int fromIdx = GetNodeIndex(from);
        int toIdx = GetNodeIndex(to);

        return base.AddEdgeCycle(fromIdx, toIdx, weight);
    }
    
    //노선도 출력
    public void PrintStastionLine()
    {
        Console.Write("지하철 역 목록 :");
        
        foreach (var node in _nodes)
        {
            Console.Write($"{node} ");
        }

        Console.WriteLine();
    }
    
    //최단 경로 탐색(다익스트라 알고리즘)
    public void FindShortestPath(string start, string dst)
    {
        //from, to 입력값 유효성 체크
        if (!HasNode(start) || !HasNode(dst))
        {
            Console.WriteLine("출발지 역 혹은 도착지 역이 존재하지 않습니다.");
            return;
        }

        //다익스트라 알고리즘
        int n = _nodes.Count; //노드(역) 개수
        double[] distance = new double[n]; //최단 거리 저장
        bool[] visited = new bool[n]; //방문 여부
        //경로를 저장하고 얘를 출력 혹은 반환해야함 => 이를 위한 변수가 필요함
        int[] previous = new int[n]; //경로 추적용. 이전 노드의 인덱스를 저장해보자

        //최단 거리를 저장하는 배열을 초기화
        for (int i = 0; i < n; i++)
        {
            distance[i] = double.PositiveInfinity;
            previous[i] = -1;
            visited[i] = false;
        }

        //시작점은 도착점 인덱스
        int startIdx = GetNodeIndex(start);
        int dstIdx = GetNodeIndex(dst);

        //시작점은 distance 0으로 설정
        distance[startIdx] = 0;

        //우선순위 큐
        PriorityQueue<int, double> pq = new PriorityQueue<int, double>();
        pq.Enqueue(startIdx, 0);

        while (pq.Count > 0)
        {
            //큐에서 지금까지 최단거리가 구해진 것들 중에서 가장 짧은 거리를 가져온다
            pq.TryDequeue(out int curNodeIdx, out double curDistance);
            
            //도착지 도달시 종료
            if (curNodeIdx == dstIdx) break;
            
            //이미 방문했다면 패스
            if(visited[curNodeIdx]) continue;
            visited[curNodeIdx] = true;
            
            //최단 거리보다 큰 거리로 큐에 들어온 경우 무시
            if (curDistance > distance[curNodeIdx]) continue;
            
            
            //인접노드를 탐색해서 새로운 경로의 거리 계산 & 최단 거리 갱신
            for (int i = 0; i < n; i++)
            {
                //인접 노드 인지 확인
                if(double.IsNaN(_adjMatrix[curNodeIdx, i])) continue;
                
                //새로운 경로 계산
                double newDistance = curDistance + _adjMatrix[curNodeIdx, i];
                //새로운 경로와 기존 거리 비교
                if (newDistance < distance[i])
                {
                    distance[i] = newDistance;
                    pq.Enqueue(i, newDistance);
                    previous[i] = curNodeIdx; //이전 노드 저장
                }
            }
            
            
        }

        PrintShortestPath(startIdx, dstIdx, distance, previous);

    }
    
    private void PrintShortestPath(int start, int dst, double[] distance, int[] previous)
    {
        //이동 경로 : 서울역 시청역 충정로역 아현역 이대역 신촌역 총 이동 수 : 5 소모 시간 : 13분
        List<string> path = new List<string>();
        int current = dst;
        while (current != -1)
        {
            path.Add(_nodes[current]);
            current = previous[current];

        }
        path.Reverse();

        Console.WriteLine($"이동 경로: {string.Join(" → ", path)}");
        Console.WriteLine($"총 이동 수 : {path.Count - 1}, 소모 시간: {distance[dst]}분");
    }

}