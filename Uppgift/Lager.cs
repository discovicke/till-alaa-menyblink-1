

public abstract class Lager
{
    public string Namn;
    public int Antal;
    public int Prislapp;
    public Lager(string namn, int antal, int prislapp)
    {
        this.Namn = namn;
        this.Antal = antal;
        this.Prislapp = prislapp;
    }
   

    public abstract void VisaInfo();
}