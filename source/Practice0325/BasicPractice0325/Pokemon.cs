namespace BasicPractice0325;

public enum Type
{
    Normal, Fire, Water, Grass, Electric, Ice, Fighting, Poison, Ground, Flying, Psychic, Bug, Rock, Ghost,Dragon, Dark, Steel, Fairy
}

//모든 포켓몬의 공통 부모 클래스 
public abstract class Pokemon
{
    //멤버 변수
    protected string name; //이름
    protected int level; //레벨
    protected Type type; //타입
    protected string skillName; //스킬 이름
    
    //프로퍼티
    public string Name => name;
    
    
    //멤버 메서드
    //Print : 포켓몬 정보 출력
    public void Print()
    {
        Console.WriteLine($"{name} Lv.{level}");
    }
    
    //Attack : 공격
    public abstract void Attack();
    
    
    //생성자
    public Pokemon(string name, int level, Type type, string skillName)
    {
        this.name = name;
        this.level = level;
        this.type = type;
        this.skillName = skillName;
    }

}