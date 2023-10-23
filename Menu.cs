using game;

class Menu
{
    private readonly string[] options;
    private int selectedIndex;

    public Menu(string[] options)
    {
        this.options = options;
    }

    public int ShowMenu(int left, int top, int width, int height)
    {
        ConsoleKey key;

        do
        {
            //Console.Clear();
            InterFace.ConsoleApp.DrawSection(2, 2, 30, 10 + 2, "OOOO"); // رسم إطار قائمة الخيارات
            DisplayMenu(left, top, width, height);
            key = Console.ReadKey().Key;

            if (key == ConsoleKey.DownArrow && selectedIndex < options.Length - 1)
                selectedIndex++;
            else if (key == ConsoleKey.UpArrow && selectedIndex > 0)
                selectedIndex--;
        } while (key != ConsoleKey.Enter);

        return selectedIndex;
    }

    private void DisplayMenu(int left, int top, int width, int height)
    {
        Console.SetCursorPosition(left, top);
        Console.WriteLine("Select an option:");

        for (var i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.SetCursorPosition(left, top + i + 1);
            Console.WriteLine($"  {options[i]}  ");
            Console.ResetColor();
        }
    }
}