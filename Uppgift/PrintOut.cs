namespace Uppgift;

public class PrintOut
{
    public static void Centered(string text, ConsoleColor color = ConsoleColor.Gray, bool newLine = true)
    {
        int windowWidth = Console.WindowWidth;
        int leftPadding = Math.Max((windowWidth - text.Length) / 2, 0);
        Console.ForegroundColor = color;
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
        if (newLine)
            Console.WriteLine(text);
        else
            Console.Write(text);
        Console.ResetColor();
    }
}