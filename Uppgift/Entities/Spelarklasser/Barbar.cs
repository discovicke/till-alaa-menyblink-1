namespace Uppgift;

public class Barbar : Character
{
    public Barbar(string characterName, int hitPoints, int strength, int dexterity, int intelligence)
        : base(characterName, hitPoints, strength, dexterity, intelligence)
    {
    }

    public override void SpecialAbility()
    {
        Console.WriteLine($"{characterName} uses the Barbar smack!");
    }
    //TODO Färdigställ bardklassen, interface entitet etc. Copy Paste från Rogue när den klassen fungerar.
}