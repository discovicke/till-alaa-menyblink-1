public class Jacka : Lager
{
    public string farg;
    public Storlek storlek;
    public bool vattentat;
    public Jacka(string namn, int antal, string farg, bool vattentat, Storlek storlek, int prislapp) :base(namn, antal, prislapp)
    {
        this.farg = farg;
        this.vattentat = vattentat;
        this.storlek = storlek;
    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{namn} {farg} {vattentat} {storlek} {prislapp} kr");
    }
}