namespace BasicPractice0325;

public class Trainer
{
    private string name; //이름
    public string Name => name;
    private Pokemon[] pokemons; //포켓몬 보관 배열
    public Pokemon fieldPokemon;
    
    //생성자
    public Trainer(string name)
    {
        this.name = name;
        pokemons = new Pokemon[]
        {
            new Bulbasaur(), 
            new Charizard(),
            new Eevee(), 
            new Pikachu(), 
            new Snorlax(), 
            new Squirtle()
        };

        fieldPokemon = null;
    }
    
    
    //Pick(int index)
    public void Pick(int index)
    {
        if (index < 0 || index > pokemons.Length)
        {
            Console.WriteLine("오류! 포켓몬을 꺼낼 수 없습니다.");
            return;
        }
        else if (fieldPokemon == pokemons[index])
        {
            Console.WriteLine("이미 필드에 있는 포켓몬입니다!");
        }
        else
        {
            if(fieldPokemon!=null)
                Console.WriteLine($"{fieldPokemon.Name}, 돌아와!");
            fieldPokemon = pokemons[index];
            Console.WriteLine($"가라, {fieldPokemon.Name}!");
        }
    }
    
    //Print() : 자신이 가진 모든 포켓몬 이름을 출력
    public void Print()
    {
        int num = 1;
        Console.WriteLine("----- 보유 중인 포켓몬 ------");
        foreach (Pokemon pokemon in pokemons)
        {
            Console.Write($"{num++}. ");
            pokemon.Print();
            Console.WriteLine();
        }

        Console.WriteLine("---------------------------");
    }
}