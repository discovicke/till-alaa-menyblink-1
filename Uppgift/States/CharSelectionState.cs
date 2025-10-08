namespace Uppgift;

public class CharSelectionState
{
    public static void CharacterSelection(List<Character> playerList)
    {
        //TODO Listan med nyskapade spelare läses inte in förrän man startat om spelet, gissar att det är för att listan läses in innan menyn startas och sedan inte uppdateras. Hur gör man?
        if (playerList.Count == 0)
        {
            PrintOut.Centered("Inga karaktärer finns. Skapa en först!");
            PrintOut.Centered("Tryck på valfri tangent...");
            Console.ReadKey();
            return;
        }

        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            PrintOut.Centered("Välj en karaktär:", ConsoleColor.DarkYellow);

            for (int i = 0; i < playerList.Count; i++)
            {
                var c = playerList[i];
                PrintOut.Centered($"{c.characterName} ({c.GetType().Name}, {c.hitPoints} HP)", i == selectedIndex ? ConsoleColor.Green : ConsoleColor.DarkGray);
            }
            PrintOut.Centered("[ENTER] Välj  |  [ESC] Tillbaka", ConsoleColor.DarkRed);

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + playerList.Count) % playerList.Count;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % playerList.Count;
            }
            else if (key == ConsoleKey.Enter)
            {
                var selectedPlayer = playerList[selectedIndex];
                Console.Clear();
                PrintOut.Centered($"Du valde: {selectedPlayer.characterName} ({selectedPlayer.GetType().Name})");
                selectedPlayer.ShowStats();
                PrintOut.Centered("\nTryck på valfri tangent för att återgå till menyn...");
                Console.ReadKey();
                return;
            }
            else if (key == ConsoleKey.Escape)
            {
                return;
            }
        }
    }
}