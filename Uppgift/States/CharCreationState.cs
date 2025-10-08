using Uppgift;
public static class CharCreationState
{
    public static Character CreateNewCharacter()
    {
        Console.Clear();
        Console.CursorVisible = false;

        // Välkomstruta
        PrintOut.Centered("> SKAPA NY KARAKTÄR <", ConsoleColor.DarkYellow);
        PrintOut.Centered("Vill du skapa din egen karaktär?\n", ConsoleColor.DarkGreen);
        PrintOut.Centered("Du kommer få välja mellan tre olika klasser och rulla fram dina stats med tärningar. (4D6, lägsta tärningen slängs)", ConsoleColor.DarkGray);
        Console.ResetColor();
        Console.WriteLine();

        // Namn
        Console.CursorVisible = true;
        PrintOut.Centered("Vad är namnet på äventyraren? ");
        string? characterName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(characterName))
        {
            characterName = "Anonym";
        }
        Console.CursorVisible = false;

        // Klass
        string className = ChooseClass();

        // Rulla stats
        int[] rolledStats = RollStats();

        // Välj stats med samma UI/menystil
        int strength = ChooseStat("Strength", rolledStats);
        int dexterity = ChooseStat("Dexterity", rolledStats);
        int intelligence = rolledStats[0]; // det som blir kvar

        // HP
        Tärningar d12 = new Tärningar(ETärningar.D12, "D12");
        int hpRoll = d12.Roll(2);
        int hitPoints = hpRoll + ((strength - 10) / 2);

        // Skapa karaktären via fabriken
        var newCharacter = CharacterFactory.CreateCharacter(characterName, className, hitPoints, strength, dexterity, intelligence);

        FileReadWrite.SavePlayerToFile(newCharacter);

        Console.WriteLine();
        PrintOut.Centered($"Karaktären {characterName} skapad och sparad!", ConsoleColor.Green);
        PrintOut.Centered("Tryck på valfri tangent för att återgå till menyn...");
        Console.ReadKey();
        return newCharacter;
    }

    private static string ChooseClass()
    {
        string[] classes = { "Rogue", "Barbar", "Bard" };
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            PrintOut.Centered("Välj klass med piltangenterna och tryck ENTER:");
            for (int i = 0; i < classes.Length; i++)
            {
                PrintOut.Centered($"  {classes[i]}", i == selectedIndex ? ConsoleColor.Yellow : ConsoleColor.DarkGray);
            }

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow || key == ConsoleKey.UpArrow) selectedIndex = (selectedIndex - 1 + classes.Length) % classes.Length;
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow) selectedIndex = (selectedIndex + 1) % classes.Length;
            else if (key == ConsoleKey.Enter) return classes[selectedIndex];
        }
    }

    private static int[] RollStats()
    {
        Tärningar d6 = new Tärningar(ETärningar.D6, "D6");
        int[] stats = new int[3];
        for (int i = 0; i < 3; i++)
        {
            stats[i] = Tärningar.RollStat(d6);
        }
        Console.WriteLine();
        PrintOut.Centered("Du rullade fram:");
        for (int i = 0; i < stats.Length; i++)
        {
            PrintOut.Centered($"  {i + 1}: {stats[i]}");
        }

        return stats;
    }

    private static int ChooseStat(string statName, int[] rolledStats)
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            PrintOut.Centered($"Välj vilken som ska bli {statName}:");
            
            //TODO Statsen tilldelas ej i rätt ordning enligt array, de måste raderas från arrayen och flyttas enhetligt så att varje stat används och bara används en gång.
            for (int i = 0; i < rolledStats.Length; i++)
            {
                PrintOut.Centered($"  {rolledStats[i]}", i == selectedIndex ? ConsoleColor.Yellow : ConsoleColor.DarkGray);
            }

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow || key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + rolledStats.Length) % rolledStats.Length;
            }
            else if (key == ConsoleKey.RightArrow || key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % rolledStats.Length;
            }
            else if (key == ConsoleKey.Enter)
            {
                int selectedStat = rolledStats[selectedIndex];

                // Ta bort det valda
                List<int> remaining = new List<int>();
                for (int i = 0; i < rolledStats.Length; i++)
                    if (i != selectedIndex) remaining.Add(rolledStats[i]);
                rolledStats = remaining.ToArray();

                return selectedStat;
            }
        }
    }
}
