using Uppgift;

namespace Uppgift;


public class Enemy : IEntitet
{
    public string name;
    public int health;
    public ETärningar attackDice;
    public Weapon? equippedWeapon = null;

    public Enemy(string name, int health, ETärningar attackDice)
    {
        this.name = name;
        this.health = health;
        this.attackDice = attackDice;
    }

    public void DealDamage()
    {
        // Spelare med vapen
        Weapon svärd = new Weapon("Rostigt svärd", 2, ETärningar.D6);

        // I spelkoden
        if (equippedWeapon == null)
        {
            Console.WriteLine("Du har inget vapen!");
        }
        else
        {
            equippedWeapon.RollDamage(); // funkar, men gör bara 1 skada
        }

        svärd.RollDamage(); // t.ex. "Rostigt svärd gör 7 skada!"
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Console.WriteLine($"{name} tar {amount} skada ({health} HP kvar)");
    }
}
