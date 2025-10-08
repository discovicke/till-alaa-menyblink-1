public class Jeans : Lager
{
    public bool stretch;
    public Storlek storlek;
    public Jeans(string namn, int antal, bool stretch, Storlek storlek, int prislapp) : base(namn, antal, prislapp)
    {
        this.stretch = stretch;
        this.storlek = storlek;
    }
    public override void VisaInfo()
    {
        Console.WriteLine($"{namn} {stretch} {storlek} {prislapp} kr");
    }
}