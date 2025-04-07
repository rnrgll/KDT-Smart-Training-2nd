namespace Practice0401_Test3;

public class Armor : Item
{
    public Armor(ActivationType activationType, string name, string description, int price, int effect, bool isPermanent=false) : base(activationType, name, description, price, effect, isPermanent)
    {
        itemType = ItemType.Armor;
    }

    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        player.DefenseIncrease += effect;
        PrintEffectInfo();
    }
    public override void RemoveEffect(Player player)
    {
        base.RemoveEffect(player);
        player.DefenseIncrease -= effect;
        PrintEffectInfo();
        
    }

    protected override void PrintEffectInfo()
    {
        Console.WriteLine($"방어력 {(isPermanent?"영구":"")}{(effect>0?"상승":"감소")} {effect}");

    }
}