namespace Uppgift;

public static class CharacterFactory
{
    public static Character CreateCharacter(string name, string? className, int hp, int str, int dex, int intel)
    {
        className ??= "Rogue"; // default
        switch (className)
        {
            case "Rogue": return new Rogue(name, hp, str, dex, intel);
            case "Barbar": return new Barbar(name, hp, str, dex, intel);
            case "Bard": return new Bard(name, hp, str, dex, intel);
            default: throw new Exception("Okänd klass: " + className);
        }
    }
}