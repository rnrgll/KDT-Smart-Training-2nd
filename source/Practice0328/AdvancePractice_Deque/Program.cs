namespace AdvancePractice_Deque;

class Program
{
    static void Main(string[] args)
    {
        MyDeque<int> testDeque = new();

        Console.WriteLine("Push front 테스트");
        for (int i = 0; i < 3; i++)
        {
            testDeque.PushFront(i);
            testDeque.PrintDeque();
        }

        Console.WriteLine();
        
        Console.WriteLine("Push back 테스트");
        for (int i = 0; i < 3; i++)
        {
            testDeque.PushBack(i);
            testDeque.PrintDeque();
        }

        Console.WriteLine();

        
        Console.WriteLine("Pop back 테스트");
        for (int i = 0; i < 4; i++)
        {
            testDeque.PopBack();
            testDeque.PrintDeque();
        }

        Console.WriteLine();
        
        
        Console.WriteLine("Pop front 테스트");
        for (int i = 0; i < 2; i++)
        {
            testDeque.PopFront();
            testDeque.PrintDeque();
        }

        Console.WriteLine();
        Console.WriteLine();
        
        
        for (int i = 0; i < 5; i++)
        {
            testDeque.PushFront(i);
        }
        
        testDeque.PrintDeque();
        Console.WriteLine("Clear 테스트");
        testDeque.Clear();
        testDeque.PrintDeque();


    }
}