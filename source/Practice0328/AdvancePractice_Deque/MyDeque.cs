namespace AdvancePractice_Deque;

public class MyDeque<T>
{
    private T[] myDeque;                 // 배열을 사용해 구현한다 (원형 배열)
    private int DEFAULT_CAPACITY = 10;   // 초기 사이즈

    private int front;   // 전단 인덱스 : 첫번째 요소의 하나 앞을 가리키도록
    private int back;    // 후단 인덱스 : 마지막 요소를 가리키도록


    public int Capacity => myDeque.Length;   // 덱의 용량
    public int Count
    {
        get
        {
            if (back >= front) return back - front;
            else return Capacity - front + back;
        }
    }
    
    //----이렇게 해도 되는데, front랑 back을 사용해서 구현해보자.
    //public bool IsEmpty => Count == 0;                  // 덱이 공백 상태인지 검사
    //public bool IsFull => Count == Capacity;    // 덱이 포화상태인지 검사

    public bool IsEmpty => front == back;
    public bool IsFull => MoveIndexBackward(back) == front;
    
    
    //create, init -> 생성자로 구현
    public MyDeque()
    {
        //클래스의 인스턴스 생성 시 최초 10의 크기를 가진다
        myDeque = new T[DEFAULT_CAPACITY];
        front = 0;
        back = 0;
    }
    
    // 덱의 앞/뒤로 인덱스를 이동시키는 메서드 (원형 배열)
    // 인덱스 앞으로(좌측으로)
    public int MoveIndexForward(int index)
    {
        return (index - 1 + Capacity) % Capacity;
    }
    // 인덱스 뒤로(우측으로)
    public int MoveIndexBackward(int index)
    {
        return (index + 1) % Capacity;
    }
    
   
    
    //배열 재할당하는 메서드
    private void ResizeArray()
    {
        //현재 배열 크기의 2배만큼의 크기를 갖는 배열을 생성
        T[] newDeque = new T[Capacity * 2];

        int index = MoveIndexBackward(front); //첫 번째 요소부터 시작
        for (int i = 0; i < Count; i++)
        {
            newDeque[i] = myDeque[index];
            index = MoveIndexBackward(index);
        }
        
        //front back 인덱스 조정
        front = Capacity * 2 - 1; //새 배열의 마지막(가장 첫 요소의 '앞'을 가리키도록)
        back = Count - 1;

        //참조 변경
        myDeque = newDeque;
    }
    

    
    
    /// <summary>
    /// 덱의 앞에 요소를 추가한다.
    /// </summary>
    /// <param name="element"></param>
    public void PushFront(T element)
    {
        //덱이 포화 상태 인지 체크한다. 포화상태면 배열을 새로운 크기로 재할당해야 한다.
        if(IsFull) ResizeArray();
        
        //front 위치에 요소를 넣고
        myDeque[front] = element;
        
        //front를 앞으로 이동시킨다.
        front = MoveIndexForward(front);
    }
    
    /// <summary>
    /// 덱의 뒤에 요소를 추가한다.
    /// </summary>
    /// <param name="element"></param>
    public void PushBack(T element)
    {
        //포화 상태인지 체크한다
        if(IsFull) ResizeArray();
        
        //back을 뒤로 옮기고
        back = MoveIndexBackward(back);
        
        //back 위치에 요소를 넣는다.
        myDeque[back] = element;
    }


    /// <summary>
    /// 덱의 앞에서 요소를 꺼내와 반환 후 삭제한다.
    /// </summary>
    /// <returns></returns>
    public T PopFront()
    {
        T element = PeekFront();
        
        //front를 뒤로 이동시키고
        front = MoveIndexBackward(front);
        //그 위치에 있는 요소 제거
        myDeque[front] = default;
        
        return element;
    }

    public T PopBack()
    {
        T element = PeekBack();
        
        //요소를 제거하고
        myDeque[back] = default;
        //back을 앞으로 이동시킨다
        back = MoveIndexForward(back);

        return element;
    }

    /// <summary>
    /// 덱의 앞에 있는 요소를 반환만 한다.
    /// </summary>
    /// <returns></returns>
    public T PeekFront()
    {
        //공백 상태인지 확인한다. 공백상태면 에러
        if (IsEmpty) throw new InvalidOperationException("덱이 공백상태입니다.");

        return myDeque[MoveIndexBackward(front)];

    }

    /// <summary>
    /// 덱의 뒤에 있는 요소를 반환만 한다.
    /// </summary>
    /// <returns></returns>
    public T PeekBack()
    {
        //공백 상태인지 확인한다. 공백상태면 에러
        if (IsEmpty) throw new InvalidOperationException("덱이 공백상태입니다.");

        return myDeque[back];
    }

    
         
    //덱의 모든 데이터를 삭제한다.
    public void Clear()
    {
        Array.Clear(myDeque, 0, Capacity);
        front = back = 0;
    }

    //출력 함수
    public void PrintDeque()
    {
        Console.Write($"DEQUE(front = {front}  back = {back}) = ");
        
        if(IsEmpty) return;
        
        int idx = front;
        while (true)
        {
            idx = MoveIndexBackward(idx); 
            //출력
            Console.Write($"{myDeque[idx]} | ");
            
            //back까지 출력했으면 종료
            if(idx == back) break;
        }
        Console.WriteLine();
        
    }

}