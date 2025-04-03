namespace Practice0401;

public abstract class Monster
{
    //이름 : 몬스터들마다 이름이 다름
    private string name;
    public string Name => name;

    public Monster(string name)
    {
        this.name = name;
    }
    
    
    //공격 가능 : 몬스터마다 공격 방법이 다름 -> 추상 메서드로 구현하기
    public abstract void Attack();



}

public class Pikachu : Monster
{
    //생성자
    public Pikachu(string name) : base(name) { }
    public Pikachu() : base("피카츄") { }

    public override void Attack()
    {
        Console.WriteLine("백만볼트!");
    }
}

public class Charmander : Monster
{
    public Charmander(string name) : base(name) {}
    public Charmander():base("파이리"){}
    
    public override void Attack()
    {
        Console.WriteLine("화염방사!");
    }
}

public class Squirtle : Monster
{
    public Squirtle(string name) : base(name) { }

    public Squirtle() : base("꼬북이") { }

    public override void Attack()
    {
        Console.WriteLine("물총발사!");
    }
}

public class Bulbasaur : Monster
{
    public Bulbasaur(string name) : base(name) { }
    public Bulbasaur():base("이상해씨"){}
    
    public override void Attack()
    {
        Console.WriteLine("덩굴채찍!");
    }
}

