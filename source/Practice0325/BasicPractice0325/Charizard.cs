namespace BasicPractice0325;

public class Charizard : Pokemon
{
    //생성자
    public Charizard() : base("리자몽", 42, Type.Fire, "화염방사")
    {
        
    }

    //추상 메서드 구현
    public override void Attack()
    {
        Console.WriteLine($"{name} {skillName}!!!");
    }
}