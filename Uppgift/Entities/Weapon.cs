namespace Uppgift;

public class Weapon
{
    public string? name;
    public int? damageBonus;
    public ETärningar? diceType;

    public Weapon(string? name, int? damageBonus, ETärningar? diceType)
    {
        this.name = name;
        this.damageBonus = damageBonus;
        this.diceType = diceType;
    }

    public int RollDamage()
    {
        // Om vapnet inte har någon tärning eller skada, gör minimal skada

        // Skapa tärning baserat på vapnets typ
        Tärningar tärning = new Tärningar(diceType.Value, diceType.Value.ToString());

        if (diceType == null)
        {
            Console.WriteLine("Du har inget vapen, du försöker slå med nävarna!");
            return 1; // bas-skada för obeväpnad attack
        }
        
        // Rolla 1 tärning och lägg till ev. bonus
        int bonus = damageBonus ?? 0; // använd 0 om null
        int damage = tärning.Roll(1) + bonus;

        Console.WriteLine($"{name ?? "Obeväpnat slag"} gör {damage} skada!");
        return damage;
    }
}