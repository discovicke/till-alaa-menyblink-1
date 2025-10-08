public abstract class Lager
{
    public string? namn;
    public int antal;
    public int prislapp;
    public Lager(string namn, int antal, int prislapp)
    {
        this.namn = namn;
        this.antal = antal;
        this.prislapp = prislapp;
    }
   

    public abstract void VisaInfo();
}