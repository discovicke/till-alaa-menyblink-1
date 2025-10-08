

public class Jeans : Lager
{
    public bool Stretch;
    public Storlek Storlek;
    public Jeans(string namn, int antal, bool stretch, Storlek storlek, int prislapp) : base(namn, antal, prislapp)
    {
        
    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{Namn} {Stretch} {Storlek} {Prislapp} kr");
    }
}