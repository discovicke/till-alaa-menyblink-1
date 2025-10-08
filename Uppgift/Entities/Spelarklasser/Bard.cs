namespace Uppgift;

public class Bard : Character
{
    public Bard(string characterName, int hitPoints, int strength, int dexterity, int intelligence)
        : base(characterName, hitPoints, strength, dexterity, intelligence)
    {
    }
    public override void SpecialAbility()
    {
        Console.WriteLine($"{characterName} uses the Bard spell!");
    }
    
    //TODO Färdigställ bardklassen, interface entitet etc. Copy Paste från Rogue när den klassen fungerar.
}