// namespace Practice0327;
//
// public abstract class Item
// {
//     //이름
//     public string Name { get; private set; }
//     //내구도
//     private int durability;
//     private int maxDurability;
//     public int Durability
//     {
//         get => durability;
//         set
//         {
//             durability = value;
//             if (durability <= 0)
//             {
//                 durability = 0;
//                 onItemBroken?.Invoke(this);
//             }
//         }
//     }
//     
//     
//     //델리게이트
//     public event Action<Item> onItemBroken;
//     
//     //생성자
//     protected Item(string name, int maxDurability)
//     {
//         this.Name = name;
//         this.durability = maxDurability;
//         this.maxDurability = maxDurability;
//     }
//     
//     
//     //내구도 변화
//     public void UpdateeDurability(int amount)
//     {
//         Durability += amount;
//
//         Console.WriteLine($"{Name}의 내구도가 {amount} {(amount>0?"증가했습니다.":"감소했습니다.")}");
//     }
//     
//     
// }