public class Hoodies : Lager
{
    public string F�rg;
    public Storlek Storlek;
    
    public Hoodies(string namn, int antal , string f�rg, Storlek storlek, int prislapp) :base(namn, antal, prislapp)
    {
      F�rg = f�rg;
    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{Namn} {F�rg} {Storlek} {Prislapp} kr");
    }
}