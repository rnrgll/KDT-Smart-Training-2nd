namespace BasicPractice0325;

public class Snorlax : Pokemon
{
    //생성자
    public Snorlax() : base("잠만보", 33, Type.Normal, "몸통박치기")
    {
        
    }

    //추상 메서드 구현
    public override void Attack()
    {
        Console.WriteLine($"{name} {skillName}!!!");
    }
}