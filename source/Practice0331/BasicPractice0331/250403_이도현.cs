namespace BasicPractice0331;

class Program
{
    static void Main(string[] args)
    {
        var graph = new WeightedMatrixGraph<string>(10); // 최대 10개 노드 수용 가능

        // 노드 추가
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");

        // 간선 추가
        graph.AddEdge(0, 1, 1.5); // A -> B
        graph.AddEdge(0, 2, 2.0); // A -> C
        graph.AddEdegeCycle(1, 3, 3.5); // B <-> D
        graph.AddEdegeCycle(2, 3, 4.0); // C <-> D

        // 잘못된 간선 추가 (음수)
        graph.AddEdge(1, 2, -1.0); //가중치는 음수가 될 수 없습니다.

        // 잘못된 간선 추가 (인덱스 오류)
        graph.AddEdge(5, 0, 1.0); //노드의 인덱스가 유효하지 않습니다.

        // 간선 삭제
        graph.RemoveEdge(1, 3); // B -> D 삭제
        graph.RemoveEdgeCycle(2, 3); //C <-> D 삭제

        // 인접 여부 확인
        Console.WriteLine(graph.IsConnected(0, 1)); // True
        Console.WriteLine(graph.IsConnected(1, 3)); // False

        // 그래프 전체 출력
        graph.PrintGraph();
    }
    
    
    
}

/// <summary>
/// 방향 그래프(단방향 간선 추가/삭제 가능, 양방향 간선 추가/삭제 가능)
/// </summary>
/// <typeparam name="T"></typeparam>
public class WeightedMatrixGraph<T>
{
    //노드 리스트
    protected List<T> _nodes = new();
    //인접 행렬(가중치 저장)
    private double[,] _adjacencyMatrix;
    
    //생성자
    public WeightedMatrixGraph(int capacity)
    {
        _adjacencyMatrix = new double[capacity, capacity];
        
        //초기화
        for (int i = 0; i < capacity; i++)
        {
            for (int j = 0; j < capacity; j++)
            {
                _adjacencyMatrix[i, j] = double.NaN;
            }
        }
    }
    
    
    //필수 기능들 : 노드 추가, 간선 추가, 간선 삭제, 인접 여부 반환, 그래프 출력
    
    //노드 추가
    public void AddNode(T value)
    {
        _nodes.Add(value); //노드들을 저장하는 리스트에 노드의 값? 노드를 넣는다.
    }
    
    //간선 추가
    public bool AddEdge(int from, int to, double weight)
    {
        if (weight < 0)
        {
            Console.WriteLine("가중치는 음수가 될 수 없습니다.");
            return false;
        }

        if (from >= _nodes.Count || to >= _nodes.Count)
        {
            Console.WriteLine("노드의 인덱스가 유효하지 않습니다.");
            return false;
        }
        _adjacencyMatrix[from, to] = weight;
        return true;
    }

    public bool AddEdegeCycle(int from, int to, double weight)
    {
        bool isSuccess1 = AddEdge(from, to, weight);
        if (!isSuccess1) return false;
        bool isSuccess2 = AddEdge(to, from, weight);
        return isSuccess1 && isSuccess2;
    }
    
    //간선 삭제
    public bool RemoveEdge(int from, int to)
    {
        if (from >= _nodes.Count || to >= _nodes.Count)
        {
            Console.WriteLine("노드의 인덱스가 유효하지 않습니다.");
            return false;
        }

        if (IsConnected(from, to))
        {
            _adjacencyMatrix[from, to] = double.NaN;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveEdgeCycle(int from, int to)
    {
        bool isSuccess1 = RemoveEdge(from, to);
        if (!isSuccess1) return false;

        bool isSuccess2 = RemoveEdge(to, from);
        return isSuccess1 && isSuccess2;
    }
    
    //인접여부 반환
    public bool IsConnected(int from, int to)
    {
        if (from >= _nodes.Count || to >= _nodes.Count)
        {
            Console.Write("노드의 인덱스가 유효하지 않습니다.");
            return false;
        }
        return _adjacencyMatrix[from, to] != double.NaN && _adjacencyMatrix[from, to] >= 0;
    }
    
    //그래프 출력
    public void PrintGraph()
    {
        for(int i=0; i<_nodes.Count;i++)
        {
            Console.Write($"{_nodes[i]}노드 :");
            for (int j = 0; j< _nodes.Count; j++)
            {
                if(_adjacencyMatrix[i,j]>=0 && !double.IsNaN(_adjacencyMatrix[i,j]))
                {
                    Console.Write($"- {_nodes[j]}노드, 가중치 {_adjacencyMatrix[i,j]} ");
                }
            }
            Console.WriteLine();
        }
    }
}