public class Jacka : Lager
{
    public string F�rg;
    public Storlek Storlek;
    public bool Vattent�t;
    public Jacka(string namn, int antal, string f�rg, bool vattent�t, Storlek storlek, int prislapp) :base(namn, antal, prislapp)
    {
        F�rg = f�rg;
    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{Namn} {F�rg} {Vattent�t} {Storlek} {Prislapp} kr");
    }
}