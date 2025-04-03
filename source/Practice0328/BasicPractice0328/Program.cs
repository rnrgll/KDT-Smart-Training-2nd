namespace BasicPractice0328;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("====값 형식 테스트====");
        MyStack<int> stack1 = new MyStack<int>();
        stack1.Push(3);
        stack1.Push(7);
        stack1.Push(5);
        stack1.Push(11);
        stack1.Push(11);
        stack1.Push(1);
        stack1.Print(); // 3 7 5 11 11 1

        Console.WriteLine(stack1.Peek()); // 1
        Console.WriteLine(stack1.Pop());  // 1
        stack1.Print();                   // 3 7 5 11 11

        stack1.Clear();
        Console.WriteLine("현재 stack에 있는 요소 개수 : {0}", stack1.Count); //현재 stack에 있는 요소 개수 : 0
        stack1.Print();                   // 없음

        Console.WriteLine();
        Console.WriteLine();
        
        Console.WriteLine("====참조 형식 테스트====");
        MyStack<string> stack2 = new MyStack<string>();
        
        stack2.Push("가");
        stack2.Push("나");
        stack2.Push("다");
        stack2.Print(); // 가 나 다
        
        Console.WriteLine(stack2.Pop()); // 다
        Console.WriteLine(stack2.Peek()); // 나
        stack2.Print(); // 가 나

        stack2.Clear();
        Console.WriteLine("현재 stack에 있는 요소 개수 : {0}", stack2.Count); //현재 stack에 있는 요소 개수 : 0
        stack2.Print(); // 없음

        Console.WriteLine();
        
        Console.WriteLine("==== Resize 테스트 =====");
        for (int i = 1; i <= 15; i++)
        {
            stack1.Push(i);
            stack2.Push("Item" + i);
        }
        
        stack1.Print(); //1 2 3 4 5 6 7 8 9 10 11 12 13 14 15
        stack2.Print(); // Item1 ~ Item15
        
    }
}