namespace Practice0401;

public class Util
{
    public static void Swap<T>(ref T left, ref T right)
    {
        //값 형식(T가 struct 등)인 경우: 값을 직접 바꾼다
        //참조 형식(T가 class 등)인 경우: 참조(주소) 자체를 바꿔서 원래 변수가 다른 객체를 가리키게 된다. 즉, 참조(주소)를 바꿔서 호출자 변수가 서로 객체를 바꿔서 참조하게 됨
        T temp = left;
        left = right;
        right = temp;
    }
}