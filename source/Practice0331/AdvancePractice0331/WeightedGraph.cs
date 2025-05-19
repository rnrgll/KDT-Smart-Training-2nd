namespace AdvancePractice0331;


//가중치 그래프
//인접행렬로 구현 (가중치 저장)
public class WeightedGraph <T>
{
    //노드
    protected List<T> _nodes;

    //인접행렬
    protected double[,] _adjMatrix;

    public WeightedGraph(int capacity)
    {
        _nodes = new List<T>(capacity);
        _adjMatrix = new double[capacity, capacity];
        
        //초기화
        for (int i = 0; i < capacity; i++)
        {
            for (int j = 0; j < capacity; j++)
            {
                _adjMatrix[i, j] = double.NaN;
            }
        }
    }
    
    
    //노드 추가
    public bool AddNode(T value)
    {
        if (HasNode(value)) return false;
        
        _nodes.Add(value);
        return true;
    }
    
    
    //간선 추가
    public bool AddEdge(int from, int to, double weight)
    {
        if (from >= _nodes.Count || to >= _nodes.Count)
        {
            Console.WriteLine("노드의 인덱스가 유효하지 않습니다.");
            return false;
        }
        _adjMatrix[from, to] = weight;
        return true;
    }

    public bool AddEdgeCycle(int from, int to, double weight)
    {
        bool isSuccess1 = AddEdge(from, to, weight);
        if (!isSuccess1) return false;
        bool isSuccess2 = AddEdge(to, from, weight);
        return isSuccess1 && isSuccess2;
    }

    //노드 인덱스 가져오기(이름으로)
    protected int GetNodeIndex(T value)
    {
        return _nodes.IndexOf(value);
    }
    
    //노드 존재 여부 확인
    public bool HasNode(T value)
    {
        return _nodes.Contains(value);
    }
    
    //노드 목록 출력
    public void PrintNodes()
    {
        Console.Write("노드 목록 : ");
        foreach (var node in _nodes)
        {
            Console.Write($"{node} ");
        }

        Console.WriteLine();
    }
    
}
