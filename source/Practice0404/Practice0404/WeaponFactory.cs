namespace Practice0404;

public class WeaponFactory
{
    public static Weapon Create(string type, Rarity rarity)
    {
        string name = "";
        float attack = 0f;
        float attackRange = 0f;
        float bonusRate = 0f;
        switch (type)
        {
            case "철검":
                name = type;
                attack = 20f;
                attackRange = 1.5f;
                break;
            case "나무창":
                name = type;
                attack = 10f;
                attackRange = 2.0f;
                break;
            case "쇠도끼":
                name = type;
                attack = 15f;
                attackRange = 1.3f;
                break;
            default:
                return null;
        }

        switch (rarity)
        {
            case Rarity.Normal: bonusRate = 1.0f;
                break;
            case Rarity.Rare: bonusRate = 1.1f;
                break;
            case Rarity.Legendary: bonusRate = 1.2f;
                break;
            default: bonusRate = 1.0f;
                break;
        }



        return new Weapon($"[{rarity}] {name}", attack * bonusRate, attackRange);
    }
}