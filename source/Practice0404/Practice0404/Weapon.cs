namespace Practice0404;

public class Weapon
{
    //이름, 공격력, 공격 범위를 가짐
    //종류 : 철검, 나무창, 쇠도끼
    //희귀도를 추가해서 등급에 따라 공격력 보정
    //일반 : 0, 희귀 : 10 : 전설 20 프로 증가
    
    public string Name { get; private set; }
    public float Attack { get; private set; }
    public float AttackRange { get; private set; }

    public Weapon(string name, float attack, float attackRange)
    {
        Name = name;
        Attack = attack;
        AttackRange = attackRange;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"{Name} : 공격력 {Attack}, 공격 범위 {AttackRange}");
    }
}

public enum Rarity
{
    Normal,
    Rare,
    Legendary
}
