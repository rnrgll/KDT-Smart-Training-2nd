namespace Practice0328;

public class BracketChecker
{
    static void Main(string[] args)
    {
        string input;
        bool answer = true;
        //입력
        input = Console.ReadLine();
        
        //연산
        input = input.Trim(' ');
        Stack<char> openBracketStack = new();

        foreach (char c in input)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                openBracketStack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                char openBracket = openBracketStack.Pop();
                if (c == ')') answer = openBracket == '(';
                else if (c == ']') answer = openBracket == '[';
                else answer = openBracket == '{';
            }

            if (!answer) break;

        }

        if (openBracketStack.Count > 0) answer = false;

        
        
        
        //출력
        Console.WriteLine((answer?"정상":"비정상"));
    }
}