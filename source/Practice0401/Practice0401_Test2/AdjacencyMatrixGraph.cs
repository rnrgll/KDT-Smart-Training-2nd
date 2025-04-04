namespace Practice0401_2;

public class AdjacencyMatrixGraph<T>
{
    //노드들을 담는 저장하는 리스트
    //단, 노드의 데이터(값)가 고유하다고 가정
    private List<Node<T>> _nodes;
    
    //인접 행렬
    private bool[,] _adjacencyMatrix;

    //생성자
    public AdjacencyMatrixGraph(int capacity)
    {
        //노드 리스트, 인접 행렬 초기화
        _nodes = new List<Node<T>>(capacity);
        _adjacencyMatrix = new bool[capacity, capacity];

        for (int i = 0; i < capacity; i++)
        {
            for (int j = 0; j < capacity; j++)
            {
                _adjacencyMatrix[i, j] = false;
            }
        }
    }

    //노드 추가
    public void AddNode(Node<T> node)
    {
        _nodes.Add(node);
    }


    //간선 추가
    public bool AddEdge(T from, T to)
    {
        //인덱스 찾기
        int fromIndex;
        int toIndex;

        fromIndex = FindIndexOfNode(from);
        toIndex = FindIndexOfNode(to);
        
        if (fromIndex == -1 || toIndex == -1)
        {
            throw new Exception("노드를 찾을 수 없습니다..?");
        }

        return AddEdge(fromIndex, toIndex);
    }

    public bool AddEdge(int fromIndex, int toIndex)
    {
        if (fromIndex < 0 || fromIndex >= _nodes.Count || toIndex < 0 || toIndex >= _nodes.Count)
        {
            Console.WriteLine("간선 추가 실패! 인덱스 오류!");
            return false;
        }

        _adjacencyMatrix[fromIndex, toIndex] = true;
        _adjacencyMatrix[toIndex, fromIndex] = true;

        return true;

    }


    //간선 삭제
    public bool RemoveEdge(T from, T to)
    {
        //인덱스 찾기
        int fromIndex;
        int toIndex;

        fromIndex = FindIndexOfNode(from);
        toIndex = FindIndexOfNode(to);
        
        if (fromIndex == -1 || toIndex == -1)
        {
            throw new Exception("노드를 찾을 수 없습니다..?");
        }


        return RemoveEdge(fromIndex, toIndex);
    }

    public bool RemoveEdge(int fromIndex, int toIndex)
    {
        if (fromIndex < 0 || fromIndex >= _nodes.Count || toIndex < 0 || toIndex >= _nodes.Count)
        {
            Console.WriteLine("간선 추가 실패! 인덱스 오류!");
            return false;
        }
        
        _adjacencyMatrix[fromIndex, toIndex] = false;
        _adjacencyMatrix[toIndex, fromIndex] = false;

        return true;

    }

    //연결 여부 : 노드를 매개변수로
    public bool IsConnected(T from, T to)
    {
        //인덱스 찾기
        int fromIndex;
        int toIndex;

        fromIndex = FindIndexOfNode(from);
        toIndex = FindIndexOfNode(to);

        if (fromIndex == -1 || toIndex == -1)
        {
            throw new Exception("노드를 찾을 수 없습니다..?");
            
        }

        return _adjacencyMatrix[fromIndex, toIndex];
    }
    
    //연결 여부 : 인덱스를 매개변수로
    public bool IsConnected(int fromIndex, int toIndex)
    {
        return _adjacencyMatrix[fromIndex, toIndex];
    }

    public int FindIndexOfNode(T value)
    {

        
        for (int i = 0; i < _nodes.Count; i++)
        {
            if (_nodes[i].Data.Equals(value))
            {
                return i;
            }
        }

        return -1;
    }

    
    //인접한 노드 리스트 반환
    public List<Node<T>> GetNeighbors(T value)
    {
        List<Node<T>> neighbors = new List<Node<T>>();

        int idx = FindIndexOfNode(value);
        if (idx == -1) return null;

        for (int i = 0; i < _nodes.Capacity; i++)
        {
            if (_adjacencyMatrix[idx, i]) //연결됐다면
            {
                neighbors.Add(_nodes[i]);
            }
        }

        return neighbors;
    }
    

}

public class Node<T>
{
    private T data;
    public T Data
    {
        get => data;
        set => data = value;
    }
    
    //생성자
    public Node(T data)
    {
        this.data = data;
    }
}