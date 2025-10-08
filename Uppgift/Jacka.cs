public class Jacka : Lager
{
    public string Färg;
    public Storlek Storlek;
    public bool Vattentät;
    public Jacka(string namn, int antal, string färg, bool vattentät, Storlek storlek, int prislapp) :base(namn, antal, prislapp)
    {
        Färg = färg;
    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{Namn} {Färg} {Vattentät} {Storlek} {Prislapp} kr");
    }
}