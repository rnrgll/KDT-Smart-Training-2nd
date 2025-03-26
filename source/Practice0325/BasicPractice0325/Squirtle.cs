namespace BasicPractice0325;

public class Squirtle : Pokemon
{
    //생성자
    public Squirtle() : base("꼬부기", 15, Type.Water, "물대포")
    {
        
    }

    //추상 메서드 구현
    public override void Attack()
    {
        Console.WriteLine($"{name} {skillName}!!!");
    }
}