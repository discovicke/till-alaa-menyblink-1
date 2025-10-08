
public partial class Program
{
    static void Main()
    {

        List<Lager> lager = new List<Lager>
        {
            new Tshirt("Vailent", 10, "Svart", Storlek.Large, 250),
            new Jeans("Levis", 5, true, Storlek.Medium, 800),
            new Jeans("Neuw", 3, false, Storlek.XLarge, 1000),
            new Tshirt("Hugo", 2, "Rod", Storlek.Small, 200),
            new Jacka("Burton", 4, "Gul", true, Storlek.XXLarge, 2500),
            new Hoodies("GANT", 0, "Bla", Storlek.Large, 400),
            new Hoodies("Ralph Lauren", 3, "Beige", Storlek.XLarge, 699),
        };
        int position = 0;
        string[] val = { "Tshirt", "Jeans", "Jacka", "Hoodies" };
        while (true)
        {
            Console.Clear();
            Console.WriteLine("## Valkommen till Trogsta Secondhand ##");
            for (int i = 0; i < val.Length; i++)
            {
                if (i == position) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(val[i]);

            }
            Console.ResetColor();
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow)
            {
                position--;
                if (position < 0)
                    position = val.Length - 1;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                position++;
                if (position == val.Length)
                {
                    position = 0;
                }
            }
        }
    }
}
