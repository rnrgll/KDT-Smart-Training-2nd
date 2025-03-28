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
                //스택에 아무것도 없는 상황. 열린 괄호가 없이 닫힌 괄호가 먼저 나온 상황
                //스택에 아무것도 없을 때 pop 하려고 하면 Exception 발생
                if (openBracketStack.Count == 0)
                {
                    answer = false;
                    break;
                }
                
                
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