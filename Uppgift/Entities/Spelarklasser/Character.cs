namespace Uppgift;

public abstract class Character
{
    public string? characterName;
    public int hitPoints;
    public int strength;
    public int dexterity;
    public int intelligence;
    public Weapon? equippedWeapon; 
    public Character(string? characterName, int hitPoints, int strength, int dexterity, int intelligence)
    {
        this.characterName = characterName;
        this.hitPoints = hitPoints;
        this.strength = strength;
        this.dexterity = dexterity;
        this.intelligence = intelligence;
        equippedWeapon = null;
    }
    
    public virtual void ShowStats()
    {
        Console.WriteLine($"{characterName} ({this.GetType().Name})");
        Console.WriteLine($"HP: {hitPoints}, STR: {strength}, DEX: {dexterity}, INT: {intelligence}");
        Console.WriteLine($"Vapen: {(equippedWeapon != null ? equippedWeapon.name : "Inget")}");

    }
    
    
    
    public abstract void SpecialAbility();
}
