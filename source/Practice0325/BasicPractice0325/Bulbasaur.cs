namespace BasicPractice0325;

public class Bulbasaur : Pokemon
{
    //생성자
    public Bulbasaur() : base("이상해씨", 5, Type.Grass, "덩굴채찍")
    {
        
    }

    //추상 메서드 구현
    public override void Attack()
    {
        Console.WriteLine($"{name} {skillName}!!!");
    }
}