namespace Practice0401_Test3;


public enum ItemType {Weapon, Armor, Accessory}
public enum ActivationType {Passive, Active}

public abstract class Item
{
    protected ItemType itemType;
    protected ActivationType activationType;
    protected string name;
    protected string description;
    protected int price;
    protected int effect;
    protected bool isPermanent;


    public ItemType ItemType => itemType;
    public ActivationType ActivationType => activationType;
    public string Name => name;
    public string Description => description;
    public int Price => price;
    public int Effect => effect;
    public bool IsPermanent => isPermanent;


    public Item(ActivationType activationType, string name, string description, int price, int effect,  bool isPermanent=false)
    {
        this.activationType = activationType;
        this.name = name;
        this.description = description;
        this.price = price;
        this.effect = effect;
        this.isPermanent = isPermanent;

    }


    /// <summary>
    /// 아이템이 사용 가능한 아이템(AcivationType.Active)이라면 사용하고 효과를 얻는다. 사용 불가능한 아이템(AcivationType.Passive)이라면 사용할 수 없다는 출력을 진행한다.
    /// </summary>
    /// <returns>사용 가능한 아이템인지의 여부 반환</returns>
    public bool Use(Player player)
    {
        if (activationType == ActivationType.Passive)
        {
            Console.WriteLine("사용할 수 없는 아이템입니다.");
            Console.WriteLine();
            return false;
        }

        Console.WriteLine($"{name} 을/를 사용합니다.");
        
        ApplyEffect(player); //하위 클래스에서 정의
        Console.WriteLine();
        return true;
    }


    public virtual void ApplyEffect(Player player)
    {
        Console.Write("플레이어가 다음과 같은 효과를 얻습니다 : ");
    }

    public virtual void RemoveEffect(Player player)
    {
        Console.Write("플레이어가 다음과 같은 효과를 잃습니다 : ");
    }

    protected abstract void PrintEffectInfo();


    public void PrintInfo()
    {
        Console.WriteLine(name);
        Console.WriteLine($" 가격 : {price:n0}G");
        Console.WriteLine($" 설명 : {description}");
        Console.WriteLine($"효과 : ({(activationType==ActivationType.Active?"사용":"소유")}) {(itemType==ItemType.Weapon?"공격력":(itemType==ItemType.Armor?"방어력":"체력"))} {(isPermanent?"영구":"")}{(effect>0?"상승":"감소")}");
    }
}