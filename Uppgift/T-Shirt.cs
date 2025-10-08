public class Tshirt : Lager
{
    
    public string Färg;
    public Storlek Storlek;
    public Tshirt(string namn, int antal, string färg, Storlek storlek, int prislapp) :base(namn, antal, prislapp)
    {
        Färg = färg;
        Storlek = storlek;

    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{Namn} {Färg} {Storlek} {Prislapp} kr");
    }
}