namespace Practice0401_Test3;

public class Inventory
{
    private List<Item> inventory;

    public int Count
    {
        get => inventory.Count;
    }

    public Inventory(int capacity)
    {
        inventory = new List<Item>(capacity);
    }

    //인벤토리 내 모든 아이템 출력
    public void PrintAllItems()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.Write($"{i+1}. ");
            inventory[i].PrintInfo();
            Console.WriteLine();
        }
    } 

    //조회
    public Item GetItem(int index)
    {
        if (index < 0 || index > inventory.Count)
        {
            Console.WriteLine("인덱스 범위가 잘못되었습니다.");
            return null;
        }
        return inventory[index];
    }


    //삽입
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }


    //삭제
    public bool RemoveItem(int idx)
    {
        if (idx < 0 || idx > inventory.Count) return false;
        inventory.RemoveAt(idx);
        return true;
    }

    public bool RemoveItem(Item item)
    {
        return inventory.Remove(item);
    }
    
    
    
    //아이템 사용
    public bool UseItem(int idx, Player player)
    {
        if (idx < 0 || idx > inventory.Count) return false;

        Item item = inventory[idx];
        if (item.Use(player))
        {
            RemoveItem(idx);
            return true;
        }

        return false;
    }

}