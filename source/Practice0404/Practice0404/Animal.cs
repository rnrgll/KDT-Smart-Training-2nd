namespace Practice0404;

public class Animal
{
    //이름, 생산품, 울음소리, 사료종류
    //희귀종은 특수 생산품 생산

    public string name;
    public string product;
    public string sound;
    public string feedType;
    public bool isRare;

    public void PrintInfo()
    {
        Console.WriteLine($"{name} : 생산품 {product}, 울음소리 {sound}, 사료종류 {feedType}");
    }

}