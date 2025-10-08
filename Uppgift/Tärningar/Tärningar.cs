namespace Uppgift;

public class Tärningar
{
    public int diceSides;
    public string diceName;

    public Tärningar(ETärningar diceType, string diceName)
    {
        this.diceName = diceName;
        this.diceSides = (int)diceType;
    }

    private static Random rand = new Random();

    public int Roll(int antalTärningar)
    {
        int resultat = 0;

        for (int i = 0; i < antalTärningar; i++)
        {
            resultat += rand.Next(1, diceSides + 1);
        }

        return resultat;
    }

    
    public static int RollStat(Tärningar d6)
    {
        List<int> rolls = new List<int>();

        // Rulla 4 stycken D6
        for (int i = 0; i < 4; i++)
        {
            rolls.Add(d6.Roll(1));
        }

        // Sortera och ta bort lägsta
        rolls.Sort();
        rolls.RemoveAt(0);

        return rolls.Sum(); // summan av de tre högsta
    }
}