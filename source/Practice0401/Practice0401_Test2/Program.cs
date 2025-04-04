using System.Diagnostics;

namespace Practice0401_2;

class Program
{
    static void Main(string[] args)
    {
        //맵 만들기
        AdjacencyMatrixGraph<string> map = new(8);
        
        //1. 노드 추가
        Node<string> current = new Node<string>("마을");
        map.AddNode(current); //시작 위치
        
        map.AddNode(new Node<string>("성"));
        map.AddNode(new Node<string>("묘지"));
        map.AddNode(new Node<string>("초원"));
        map.AddNode(new Node<string>("바다"));
        map.AddNode(new Node<string>("숲"));
        map.AddNode(new Node<string>("상점"));
        map.AddNode(new Node<string>("길드"));
        
        
        //2. 간선 추가
        map.AddEdge("마을", "성");
        map.AddEdge("마을", "묘지");
        map.AddEdge("성", "묘지");
        map.AddEdge("묘지", "초원");
        map.AddEdge("묘지", "바다");
        map.AddEdge("초원", "바다");
        map.AddEdge("초원", "숲");
        map.AddEdge("성", "숲");
        map.AddEdge("성", "길드");
        map.AddEdge("성", "초원");
        map.AddEdge("길드", "숲");
        map.AddEdge("길드", "상점");
        map.AddEdge("상점", "숲");
        map.AddEdge("상점", "바다");
        


        //이동 경로 저장할 변수 선언
        Stack<Node<string>> path = new Stack<Node<string>>();

        //시작 위치 설정
        path.Push(current);

        
        //변수 선언
        int choice;
        Node<string> nextNode;
        
        //이동 장소 출력 & 선택
        while (true)
        {
            choice = PrintMenu(path, map, out nextNode);

            switch (choice)
            {
                case -1:
                    Console.WriteLine("맵 이동을 종료합니다.");
                    return;
            
                case 0:
                    path.Pop(); //뒤로가기
                    current = path.Peek();
                    break;
                
                default:
                    if (nextNode != null)
                    {
                        path.Push(nextNode);
                    }
                    break;
            }

        }
       

    }

    public static int PrintMenu<T>(Stack<Node<T>> stack, AdjacencyMatrixGraph<T> map, out Node<T> nextNode)
    {
        Console.WriteLine("======== 맵 이동 ========");
        Console.WriteLine();
        PrintCurrentPos(stack); //현재 장소 출력
        PrintPath(stack); //이동 경로 출력
        
        return PrintSelection(stack.Peek(), map, out nextNode); //선택지 출력
        
        
        
    }
    
    public static void PrintCurrentPos<T>(Stack<Node<T>> stack)
    {
        Console.WriteLine("현재 장소 : {0}", stack.Peek().Data);
    }

    public static void PrintPath<T>(Stack<Node<T>> stack)
    {
        Node<T>[] path = new Node<T>[stack.Count];
        stack.CopyTo(path, 0);
        Array.Reverse(path);
        
        Console.Write("이동경로 : ");

        for (int i = 0; i < path.Length; i++)
        {
            Console.Write(path[i].Data);
            if(i!=path.Length-1) Console.Write(" > ");
        }

        Console.WriteLine();
    }
    

    public static int PrintSelection<T>(Node<T> currentNode, AdjacencyMatrixGraph<T> map, out Node<T> nextNode)
    {
        int choice = -1;
        nextNode = null;
        
        List<Node<T>> neighbors = map.GetNeighbors(currentNode.Data);
        for (int i = 0; i < neighbors.Count; i++)
        {
            Console.WriteLine($"{i+1}. {neighbors[i].Data}");
        }
        
        Console.WriteLine();
        Console.Write("이동할 장소를 선택하세요(뒤로가기 0, 종료 -1) : ");
        
        while (!int.TryParse(Console.ReadLine(), out choice) || choice<-1 || choice > neighbors.Count)
        {
            Console.Write("이동할 장소를 선택하세요(뒤로가기 0, 종료 -1) : ");
            
        }

        if(choice>0)
            nextNode = neighbors[choice - 1];
        return choice;

    }
    
    
    
}