public class Hoodies : Lager
{
    public string farg;
    public Storlek storlek;
    
    public Hoodies(string namn, int antal , string farg, Storlek storlek, int prislapp) :base(namn, antal, prislapp)
    {
      this.farg = farg;
      this.storlek = storlek;
    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{namn} {farg} {storlek} {prislapp} kr");
    }
}