namespace Uppgift;

public class GameState
{
    public static void GameLoop(List<Character> playerList)
    {
        Console.Clear();
        PrintOut.Centered("Spelet startar! Genererar rum...\n");

        // TODO: Här börjar du skapa och generera rum
        PrintOut.Centered("Press any key to return to menu...");
        Console.ReadKey();
    }
}