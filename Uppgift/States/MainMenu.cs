namespace Uppgift;

public static class MainMenu
{

    public static void ShowMenu(List<Character> playerList)
    {
        
        //TODO Enhetliga färger, snygga till. Ska göras när spelet fungerar som det ska, lättare att hitta i koden när textblocken har olika färger.
        string[] menuItems = { "STARTA SPEL", "SKAPA KARAKTÄR", "SE KARAKTÄRER", "AVSLUTA" };
        string[] infoTexts =
        {
            "Starta äventyret! Generera rum och möt fiender i en slumpmässig värld.",
            "Skapa en ny hjälte — välj namn, klass och rulla fram stats!",
            "Visa redan existerande karaktärer, se deras stats eller ta bort någon.",
            "Avsluta spelet och återvänd till skrivbordet. Tack för att du spelade!"
        };

        int selectedIndex = 0;
        bool running = true;

        while (running)
        {
            Console.Clear();

            // Rubriker
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintOut.Centered("╔══════════════════════════════════════╗");
            PrintOut.Centered("║             PLACEHOLDER              ║");
            PrintOut.Centered("╚══════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine();
            PrintOut.Centered("HUVUDMENY", ConsoleColor.DarkYellow);
            Console.WriteLine();

            // Menyval
            string menuRow = string.Join("   ", menuItems);
            int windowWidth = Console.WindowWidth;
            int leftPadding = Math.Max((windowWidth - menuRow.Length) / 2, 0);
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                Console.Write(menuItems[i]);

                // Lägg till mellanrum mellan menyerna
                if (i < menuItems.Length - 1)
                {
                    Console.Write("     "); // Mellanrum
                } 
            }
            

            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine();
            PrintOut.Centered(infoTexts[selectedIndex], ConsoleColor.Gray);
            Console.WriteLine();
            PrintOut.Centered("Använd piltangenterna för att navigera och Enter för att välja.", ConsoleColor.Cyan);
            PrintOut.Centered("<- Vänster pil  ||  Höger pil ->  ||  [ESC] Avsluta  ||  [ENTER] Välj", ConsoleColor.Magenta);

            // Tangenthantering
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;
                    break;
                case ConsoleKey.RightArrow:
                    selectedIndex = (selectedIndex + 1) % menuItems.Length;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    switch (selectedIndex)
                    {
                        case 0:
                            GameState.GameLoop(playerList);
                            break;
                        case 1:
                            CharCreationState.CreateNewCharacter();
                            break;
                        case 2:
                            CharSelectionState.CharacterSelection(playerList);
                            break;
                        case 3:
                            running = false;
                            break;
                    }
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
            }
        }
        Console.Clear();
        PrintOut.Centered("Spelet avslutas...", ConsoleColor.Red);
    }   
}
