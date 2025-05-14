// namespace Practice0327;
//
// public class Player
// {
//     public string Name => "플레이어";
//     private Inventory _inventory;
//     private Inventory _equipped;
//     
//
//     public Player()
//     {
//         _inventory = new Inventory();
//         _equipped = new Inventory();
//     }
// }
//
// public class Inventory
// {
//     private Item[] inventory;
//     public int cnt;
//
//     public Inventory() : this(null)
//     {
//        
//     }
//
//     public Inventory(params Item[] items)
//     {
//         inventory = new Item[5];
//         cnt = 0;
//         
//         if (items.Length == 0) return;
//         for (int i = 0; i < 5; i++)
//         {
//             PutItem(items[i]);
//             cnt++;
//         }
//     }
//     
//
//     public Item GetItem(int idx)
//     {
//         if (idx >= 0 && idx < inventory.Length)
//             return inventory[idx];
//        
//         return null;
//     }
//
//     public void PutItem(Item item)
//     {
//         for (int i = 0; i < inventory.Length; i++)
//         {
//             if (inventory[i] == null) inventory[i] = item;
//             return;
//         }
//
//         Console.WriteLine("인벤토리가 가득 찼습니다!!");
//     }
// }