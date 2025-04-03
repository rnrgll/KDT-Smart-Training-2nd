using System;

namespace BasicPractice0328;

public class MyStack<T>
{
    private T[] myStack;
    
    private int cnt;
    public int Count => cnt;
    
    private const int DEFAULT_CAPACITY = 10;

    public MyStack()
    {
        myStack = new T[DEFAULT_CAPACITY];
        cnt = 0;
    }

    public void Push(T element)
    {
        //스택이 가득 찼을 경우 = 스택의 크기(길이)와 cnt 값이 동일할 때
        //2배 크기로 재할당
        if (myStack.Length == cnt)
        {
            myStack = Resize(myStack.Length * 2);
        }
        
        //요소 삽입
        myStack[cnt++] = element;
    }

    public T Pop()
    {
        //스택이 비어있는 경우 오류 처리
        if (cnt == 0)
        {
            throw new InvalidOperationException("스택이 비어있습니다.");
        }

        T element = myStack[--cnt]; //마지막 요소 조회 + 꺼내기
        
        //참조형인 경우 참조 해제
        if (!typeof(T).IsValueType)
            myStack[cnt] = default(T);

        return element;

    }

    public T Peek()
    {
        //스택이 비어있는 경우 오류 처리
        if (cnt == 0)
        {
            throw new InvalidOperationException("스택이 비어있습니다.");
        }

        T element = myStack[cnt - 1]; //마지막 요소 조회 + 꺼내지 x

        return element;
    }

    public void Clear()
    {
        //참조형인 경우 참조 해제
        if (!typeof(T).IsValueType)
        {
            for (int i = 0; i < cnt; i++)
            {
                myStack[i] = default(T);
            }
        }

        cnt = 0;
    }


    private T[] Resize(int newLength)
    {
        T[] newStack = new T[newLength];
        Array.Copy(myStack, newStack, cnt); //source, destination, length

        return newStack;
    }
    
    
    
    //테스트용 : 스택에 있는 요소 모두 출력
    public void Print()
    {
        for (int i = 0; i < cnt; i++)
        {
            Console.Write($"{myStack[i]} ");
        }

        Console.WriteLine();
    }
}