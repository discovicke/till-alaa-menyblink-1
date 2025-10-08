public class Tshirt : Lager
{
    
    public string farg;
    public Storlek storlek;
    public Tshirt(string namn, int antal, string farg, Storlek storlek, int prislapp) :base(namn, antal, prislapp)
    {
        this.farg = farg;
        this.storlek = storlek;

    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{namn} {farg} {storlek} {prislapp} kr");
    }
}