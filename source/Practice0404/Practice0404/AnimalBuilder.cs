namespace Practice0404;

public class AnimalBuilder
{
    private string name;
    private string product;
    private string sound;
    private string feedType;
    private bool isRare;
    
    //생성자
    public AnimalBuilder()
    {
        name = "default";
        product = "default";
        sound = "default";
        feedType = "default";
        isRare = false;

    }


    public Animal Build()
    {
        Animal animal = new Animal();
        animal.name = $"{(isRare?"희귀한 ":"")}{name}";
        animal.product = $"{(isRare?"희귀한 ":"")}{product}";
        animal.sound = sound;
        animal.feedType = feedType;
        animal.isRare = isRare;
        return animal;
    }

    
    public AnimalBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }

    public AnimalBuilder SetProduct(string product)
    {
        this.product = product;
        return this;
    }

    public AnimalBuilder SetSound(string sound)
    {
        this.sound = sound;
        return this;
    }


    public AnimalBuilder SetFeedType(string feedType)
    {
        this.feedType = feedType;
        return this;
    }

    public AnimalBuilder SetIsRare(bool isRare)
    {
        this.isRare = isRare;
        return this;
    }
    
}