public class Hoodies : Lager
{
    public string Färg;
    public Storlek Storlek;
    
    public Hoodies(string namn, int antal , string färg, Storlek storlek, int prislapp) :base(namn, antal, prislapp)
    {
      Färg = färg;
    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{Namn} {Färg} {Storlek} {Prislapp} kr");
    }
}