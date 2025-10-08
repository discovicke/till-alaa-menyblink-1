namespace Uppgift;

public class Rogue : Character, IEntitet
{
    
    public Rogue(string characterName, int hitPoints, int strength, int dexterity, int intelligence)
        : base(characterName, hitPoints, strength, dexterity, intelligence)
    {
        
    }
    
    public override void SpecialAbility()
    {
        Console.WriteLine($"{characterName} uses Backstab! Deals {dexterity * 2} damage.");
    }

    public void DealDamage()
    {
        if (equippedWeapon == null)
        {
            Console.WriteLine($"{characterName} has no weapon equipped and cannot deal damage.");
            return;
        }
        int dexBonus = dexterity - 10 / 2;
        equippedWeapon.RollDamage();
    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}