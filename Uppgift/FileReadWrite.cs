namespace Uppgift;

public static class FileReadWrite
{
    public static void EnsurePlayerFileExists()
    {
        if (!File.Exists("players.txt"))
        {
            File.WriteAllText("players.txt", "Skuggtass,Rogue,18,8,17,10\nTrombos,Barbar,30,17,10,7\nKevelyn,Bard,20,6,13,18");
        }
    }

    public static List<Character> LoadPlayersFromFile()
    {
        var playerList = new List<Character>();
        if (!File.Exists("players.txt")) return playerList;
        var lines = File.ReadAllLines("players.txt");
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(',');
            if (parts.Length != 6) continue;
            string? characterName = parts[0].Trim();
            string? className = parts[1].Trim();
            if (string.IsNullOrWhiteSpace(characterName) || string.IsNullOrWhiteSpace(className)) continue;
            if (!int.TryParse(parts[2], out int hitPoints)) continue;
            if (!int.TryParse(parts[3], out int strength)) continue;
            if (!int.TryParse(parts[4], out int dexterity)) continue;
            if (!int.TryParse(parts[5], out int intelligence)) continue;
            playerList.Add(CharacterFactory.CreateCharacter(characterName, className, hitPoints, strength, dexterity, intelligence));
        }
        return playerList;
    }

    public static void SavePlayerToFile(Character character)
    {
        string line = $"{character.characterName},{character.GetType().Name},{character.hitPoints},{character.strength},{character.dexterity},{character.intelligence}";
        File.AppendAllText("players.txt", "\n" + line);
    }
}