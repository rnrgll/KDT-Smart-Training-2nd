namespace BasicPractice0325;

public class Eevee : Pokemon
{
    //생성자
    public Eevee() : base("이브이", 8, Type.Normal, "전광석화")
    {
        
    }

    //추상 메서드 구현
    public override void Attack()
    {
        Console.WriteLine($"{name} {skillName}!!!");
    }
}