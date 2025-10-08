using Uppgift;

public class Program
{
    static void Main()
    {
        FileReadWrite.EnsurePlayerFileExists();
        var playerList = FileReadWrite.LoadPlayersFromFile();
        MainMenu.ShowMenu(playerList);
    }
}
