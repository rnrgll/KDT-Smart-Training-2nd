namespace BasicPractice0325;

public class Pikachu : Pokemon
{
    //생성자
    public Pikachu() : base("피카츄", 10, Type.Electric, "10만 볼트")
    {
        
    }

    //추상 메서드 구현
    public override void Attack()
    {
        Console.WriteLine($"{name} {skillName}!!!");
    }
}