namespace BasicPractice0327;

public class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        SFX sfx = new();


        //player.OnTakeDamaged += sfx.HitSound; //시그니처가 일치하지 않아서 불가능!
        player.OnTakeDamaged += (damage) => { sfx.HitSound(); }; //람다함수를 사용하면 매개변수를 받고 사용하지 않으면서 sfx.HitSound 메서드를 콜백할 수 있다.
    }
}


public class Player
{
    private int hp = 100;
    public Action<int> OnTakeDamaged;

    public void TakeDamaged(int damage)
    {
        hp -= damage;
        Console.WriteLine("플레이어가 {0} 데미지를 받습니다.", damage);

        OnTakeDamaged?.Invoke(damage);
    }
}

public class SFX
{
    public void HitSound()
    {
        Console.WriteLine("피격음 사운드 재생");
    }
}