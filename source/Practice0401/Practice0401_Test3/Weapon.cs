namespace Practice0401_Test3;

public class Weapon : Item
{
    public Weapon(ActivationType activationType, string name, string description, int price, int effect,  bool isPermanent=false) : base(activationType, name, description, price, effect, isPermanent)
    {
        itemType = ItemType.Weapon;
    }

    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        player.AttackIncrease += effect;
        PrintEffectInfo();
       
    }
    public override void RemoveEffect(Player player)
    {
        base.RemoveEffect(player);
        player.AttackIncrease -= effect;
        PrintEffectInfo();
    }
    protected override void PrintEffectInfo()
    {
        Console.WriteLine($"공격력 {(isPermanent?"영구":"")}{(effect>0?"상승":"감소")} {effect}");

    }
    
}